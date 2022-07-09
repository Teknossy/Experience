using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.Entity.Models.User;
using Teknossy.Interfaces;

namespace Teknossy.Experience.DAL.DataAccess
{
    public class dalUser : dalBase<User>
    {
        public dalUser(ITicket ticket, ExperienceContext db, IMapper mapper) : base(ticket, db, mapper)
        {
        }
    }
}
