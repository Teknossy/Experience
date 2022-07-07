using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Teknossy.Experience.Entity
{
    public class BaseGeom : BaseEntity
    {
        [NotMapped]
        public string Geom { get; set; }
        public string WKTString { get; set; }
    }
}
