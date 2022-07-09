using System;
using System.Collections.Generic;
using System.Text;

namespace Teknossy.Experience.Entity.Interfaces
{
    public interface IEntity : IIdentityColumn
    {
        public string Guid { get; set; }
        public string FirstUserIp { get; set; }
        public DateTime? FirstTime { get; set; }
        public int FirstUserId { get; set; }
        public string LastUserIp { get; set; }
        public DateTime? LastTime { get; set; }
        public int? LastUserId { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IIdentityColumn
    {
        int Id { get; set; }
    }
}
