using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Teknossy.Experience.Entity.Interfaces;
using Teknossy.Interfaces;

namespace Teknossy.Experience.DAL.Interfaces
{
    public interface IdalBase<T> where T : class, IIdentityColumn
    {
        ITicket Ticket { get; set; }

        T GetirEnityById(int id);

        void Ekle(T ent);

        int EkleCoklu(List<T> ents);

        void Guncelle(T ent);

        void Guncelle(List<T> ents);

        void Sil(T ent);

        int Sil(List<T> ents);

        bool Varmi(Expression<Func<T, bool>> predicate);

        TResult Getir<TResult>(int id);

        TResult Getir<TResult>(int id, Expression<Func<T, TResult>> func);
    }
}
