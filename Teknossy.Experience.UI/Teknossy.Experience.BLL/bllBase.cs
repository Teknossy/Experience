using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Interfaces;

namespace Teknossy.Experience.BLL
{
    public class bllBase
    {
        protected readonly bllExperience _bllExperience;
        protected readonly string IslemSinifi;
        protected readonly ITicket Ticket;
        protected readonly IMapper mapper;

        protected bllBase(bllExperience bllExperience, ITicket ticket, IMapper mapperInstance = null)
        {
            _bllExperience = bllExperience;
            Ticket = ticket;
            mapper = mapperInstance;
            IslemSinifi = this.GetType().Name;
        }

        //public void LogBilgi(string mesaj)
        //{
        //    bllExperience.BllLog.LogBilgi(mesaj, IslemSinifi);
        //}

        //public void LogKritik(string mesaj)
        //{
        //    bllExperience.BllLog.LogKritik(mesaj, IslemSinifi);
        //}

        //public void LogUyari(string mesaj)
        //{
        //    bllExperience.BllLog.LogUyari(mesaj, IslemSinifi);
        //}
    }
}
