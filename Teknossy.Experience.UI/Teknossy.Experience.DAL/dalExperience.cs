using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.DAL.DataAccess.System;
using Teknossy.Experience.DAL.Interfaces;
using Teknossy.Interfaces;

namespace Teknossy.Experience.DAL
{
    public class dalExperience : IdalExperience
    {
        private IDbContextTransaction _transaction;
        private readonly ITicket _ticket;
        private readonly ExperienceContext _mdb;
        private readonly IMapper _mapper;

        public dalExperience(ITicket ticket, ExperienceContext mdb, IMapper mapper)
        {
            _ticket = ticket;
            _mdb = mdb;
            _mapper = mapper;
        }

        #region Transaction

        public IDbContextTransaction OpenTransaction()
        {
            _transaction = _mdb.Database.CurrentTransaction ?? _mdb.Database.BeginTransaction();
            return _transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        #endregion Transaction

        private dalUser _dalUser;
        public dalUser dalUser => _dalUser ??= new dalUser(_ticket, _mdb, _mapper);
    }
}
