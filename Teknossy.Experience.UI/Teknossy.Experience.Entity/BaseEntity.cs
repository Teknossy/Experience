using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Teknossy.Experience.Entity
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            FirstTime = new DateTime(2020, 3, 5, 18, 9, 34, 763, DateTimeKind.Local).AddTicks(3287);
            FirstUserIp = "127.0.0.1";
            FirstUserId = 0;
            IsActive = false;
            Guid = System.Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [StringLength(50, ErrorMessage = "GUID 50 karakterden fazla olamaz.")]
        public string Guid { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "IP adresi 50 karakterden fazla olamaz.")]
        public string FirstUserIp { get; set; }

        public DateTime? FirstTime { get; set; }

        public int FirstUserId { get; set; }

        [StringLength(50, ErrorMessage = "IP adresi 50 karakterden fazla olamaz.")]
        public string LastUserIp { get; set; }

        public DateTime? LastTime { get; set; }

        public int? LastUserId { get; set; }

        public bool IsActive { get; set; }
    }
}
