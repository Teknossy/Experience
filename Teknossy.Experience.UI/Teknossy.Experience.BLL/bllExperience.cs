using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.BLL.Interfaces;
using Teknossy.Experience.BLL.Logics.System;
using Teknossy.Experience.DAL.Interfaces;
using Teknossy.Interfaces;

namespace Teknossy.Experience.BLL
{
    public class bllExperience : IbllExperience
    {
        private IDbContextTransaction transaction;
        private readonly IdalExperience _IdalExperience;
        private readonly ITicket _ticket;
        private readonly IMapper _mapper;
        private readonly IConfigurationRoot _config;

        public bllExperience(IdalExperience IdalExperience, ITicket ticket, IMapper mapper, IConfigurationRoot config)
        {
            _IdalExperience = IdalExperience;
            _ticket = ticket;
            _mapper = mapper;
            _config = config;
        }

        public IDbContextTransaction OpenTransaction()
        {
            transaction = _IdalExperience.OpenTransaction();
            return transaction;
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public IdalExperience GetEuasDal()
        {
            return _IdalExperience;
        }

        private bllUser _bllUser;
        public bllUser bllUser => _bllUser ??= new bllUser(this, _ticket, _IdalExperience.dalUser);
    }
}
