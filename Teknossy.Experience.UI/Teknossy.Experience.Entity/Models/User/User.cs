using System;
using System.Collections.Generic;
using System.Text;

namespace Teknossy.Experience.Entity.Models.User
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
