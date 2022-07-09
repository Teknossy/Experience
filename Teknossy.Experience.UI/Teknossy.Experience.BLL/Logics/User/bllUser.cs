using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.DAL.DataAccess.User;
using Teknossy.Interfaces;

namespace Teknossy.Experience.BLL.Logics.User
{
    public class bllUser : bllBase
    {
        private readonly dalUser _dalUser;

        public bllUser(bllExperience bllExperience, ITicket ticket, dalUser dalUser) : base(bllExperience, ticket)
        {
            _dalUser = dalUser;
        }
    }
}
