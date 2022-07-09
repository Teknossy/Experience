using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Interfaces;

namespace Teknossy.Experience.DAL.DataAccess.User
{
    public class dalUser : dalBase<Teknossy.Experience.Entity.Models.User.User>
    {
        public dalUser(ITicket ticket, ExperienceContext db, IMapper mapper) : base(ticket, db, mapper)
        {
        }
    }
}
