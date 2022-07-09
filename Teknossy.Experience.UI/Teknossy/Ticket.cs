using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Interfaces;

namespace Teknossy
{
    public class Ticket : ITicket
    {
        public int? UserId { get; set; }
        public int? UserType { get; set; }
        public int? UnitId { get; set; }
        public int? ServiceId { get; set; }
        public string SessionId { get; set; }
        public string IP { get; set; }
        public bool? AddLog { get; set; }
        public int? BaseLogId { get; set; }
        public string Token { get; set; }
        public string EndPoint { get; set; }
        public string Method { get; set; }

        public Ticket()
        {
            this.AddLog = true;
            this.SessionId = Guid.NewGuid().ToString();
        }

        public Ticket(int userId)
            : this()
        {
            this.UserId = userId;
        }

        public Ticket(int userId, string ip)
            : this()
        {
            this.UserId = userId;
            this.IP = ip;
        }

        public Ticket(int userId, string ip, bool addLog)
            : this()
        {
            this.UserId = userId;
            this.IP = ip;
            this.AddLog = addLog;
        }
    }
}
