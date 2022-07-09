using System;
using System.Collections.Generic;
using System.Text;

namespace Teknossy.Interfaces
{
    public interface ITicket
    {
        int? UserId { get; set; }
        int? UserType { get; set; }
        int? UnitId { get; set; }
        int? ServiceId { get; set; }
        string SessionId { get; set; }
        string IP { get; set; }
        bool? AddLog { get; set; }
        int? BaseLogId { get; set; }
        string Token { get; set; }
        string EndPoint { get; set; }
        string Method { get; set; }
    }
}
