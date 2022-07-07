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
            IlkKayitTarihi = new DateTime(2020, 3, 5, 18, 9, 34, 763, DateTimeKind.Local).AddTicks(3287);
            IlkKayitIp = "127.0.0.1";
            IlkKayitKullaniciId = 0;
            Silindi = false;
            Guid = System.Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [StringLength(50, ErrorMessage = "GUID 50 karakterden fazla olamaz.")]
        public string Guid { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "IP adresi 50 karakterden fazla olamaz.")]
        public string IlkKayitIp { get; set; }

        public DateTime? IlkKayitTarihi { get; set; }

        public int IlkKayitKullaniciId { get; set; }

        [StringLength(50, ErrorMessage = "IP adresi 50 karakterden fazla olamaz.")]
        public string SonKayitIp { get; set; }

        public DateTime? SonKayitTarihi { get; set; }

        public int? SonKayitKullaniciId { get; set; }

        public bool Silindi { get; set; }
    }
}
