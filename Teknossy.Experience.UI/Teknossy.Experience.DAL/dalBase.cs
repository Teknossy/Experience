using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teknossy.Experience.DAL.Interfaces;
using Teknossy.Experience.Entity;
using Teknossy.Experience.Entity.Interfaces;
using Teknossy.Interfaces;

namespace Teknossy.Experience.DAL
{
    public class dalBase<T> : IdalBase<T> where T : class, IIdentityColumn, new()
    {
        protected readonly ExperienceContext db;
        protected readonly IMapper mapper;

        public ITicket Ticket { get; set; }

        protected dalBase(ITicket ticket, ExperienceContext mdb, IMapper mapperInstance = null)
        {
            Ticket = ticket;
            db = mdb;
            mapper = mapperInstance;
        }

        #region Getir

        public T GetirEnityById(int id)
        {
            try
            {
                return db.Set<T>().FirstOrDefault(i => i.Id == id);
            }
            catch (Exception ex)
            {
                var message = "Kayıt getirilirken hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        #endregion Getir

        #region Ekle

        public void Ekle(T ent)
        {
            try
            {
                var tbl = db.Set<T>();

                tbl.Add(ent);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = "Kayıt ekleme işlemi sırasında hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        public int EkleCoklu(List<T> ents)
        {
            try
            {
                db.Set<T>();

                var tbl = db.Set<T>();
                tbl.AddRange(ents);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = "Kayıt ekleme işlemi sırasında hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        #endregion Ekle

        #region Guncelle

        public void Guncelle(T ent)
        {
            try
            {
                db.Set<T>().Attach(ent);
                var current = db.Entry(ent).CurrentValues.Clone();
                db.Entry(ent).Reload();
                db.Entry(ent).CurrentValues.SetValues(current);
                db.Entry(ent).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = "Kayıt güncelleme işlemi sırasında hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        public void Guncelle(List<T> ents)
        {
            try
            {
                foreach (var ent in ents)
                {
                    db.Set<T>().Attach(ent);
                    var current = db.Entry(ent).CurrentValues.Clone();
                    db.Entry(ent).Reload();
                    db.Entry(ent).CurrentValues.SetValues(current);
                    db.Entry(ent).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = "Kayıtları güncellerken hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        #endregion Guncelle

        #region Sil

        public void Sil(T ent)
        {
            try
            {
                var tbl = db.Set<T>();
                tbl.Remove(ent);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = "Kayıt silme işlemi sırasında hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        public int Sil(List<T> ents)
        {
            try
            {
                db.Set<T>();
                var tbl = db.Set<T>();
                tbl.RemoveRange(ents);

                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                var message = "Kayıtları silerken hata oluştu.";

                throw new OperationException(message, ex);
            }
        }

        #endregion Sil

        #region Geom

        public static void UpdateGeom(BaseGeom ent, string WKTString, ExperienceContext db)
        {
            ent.Geom = WKTString;
            var tableName = GetTableName(ent, db);

            var sql = string.Format("UPDATE {1} SET \"geom\"= ST_Force2D(public.ST_GeomFromText('{2}', 4326)) WHERE \"ID\"  IN ({0})", ent.Id, tableName, WKTString);

            db.Database.ExecuteSqlRaw(sql);
        }

        #endregion

        private static string GetTableName(object ent, ExperienceContext db)
        {
            return db.Model.FindEntityType(ent.GetType()).GetTableName();
        }

        public bool Varmi(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Any(predicate);
        }

        public TResult Getir<TResult>(int id)
        {
            return db.Set<T>().Where(k => k.Id == id).ProjectTo<TResult>(mapper.ConfigurationProvider).FirstOrDefault();
        }

        public TResult Getir<TResult>(int id, Expression<Func<T, TResult>> func)
        {
            return db.Set<T>().Where(k => k.Id == id).Select(func).FirstOrDefault();
        }

        public IQueryable<TResult> GetirQueryable<TResult>()
        {
            //return db.Set<T>().OrderBy(x => x.Id).ProjectTo<TResult>(mapper.ConfigurationProvider);
            return db.Set<T>().ProjectTo<TResult>(mapper.ConfigurationProvider);
        }
        public IQueryable<T> GetirQueryable()
        {
            return db.Set<T>();
        }

        public IQueryable<TResult> GetirQueryable<TResult>(Expression<Func<T, TResult>> func)
        {
            return db.Set<T>().Select(func);
        }
    }
}
