using System;
using System.Collections.Generic;
using System.Text;

namespace Teknossy
{
    public static class Exceptions
    {
        public static class Codes
        {
            public const string islemHatasi = "E1";
            public const string parametreHatasi = "E2";
            public const string oturumHatasi = "E3";
            public const string yetkisizIslemHatasi = "E4";
            public const string tekrarliKayitHatasi = "E5";
            public const string kayitBulunamadiHatasi = "E6";
            public const string lisansHatasi = "E6";
            public const string aktifOturumHatasi = "E7";
            public static string sqlHatasi = "E11";
            public static string entityValidationError = "E12";
            public const string mobilOturumHatasi = "E13";
            public const string bagliKayitHatasi = "E14";
        }

        public static class Messages
        {
            public const string islemHatasi = "İşleminiz gerçekleştirilemedi!";
            public const string parametreHatasi = "Eksik ya da hatalı parametre girdiniz!";
            public const string oturumHatasi = "Geçerli bir oturum bulunamadı!";
            public const string yetkisizIslemHatasi = "İşlemi yapmaya yetkiniz yok!";
            public const string kullaniciPasifHatasi = "Kullanıcı pasif durumdadır! Sistem yöneticisi ile iletişime geçiniz.";
            public const string tekrarliKayitHatasi = "Girmeye çalıştığınız kayıt sisteme daha önceden kaydedildiği için işleminiz iptal edildi!";
            public const string kayitBulunamadiHatasi = "Kayıt bulunamadı!";
            public const string bagliKayitHatasi = "Silmek istediğiniz kayıt başka bir tabloda kullanılmaktadır!";
        }

        public static class Titles
        {
            public const string islemHatasi = "İşlem Hatası";
            public const string parametreHatasi = "Parametre Hatası";
            public const string oturumHatasi = "Oturum Hatası";
            public const string yetkisizIslemHatasi = "Yetkisiz İşlem Hatası";
            public const string kullaniciPasifHatasi = "Kullanıcı Hatası";
            public const string tekrarliKayitHatasi = "Tekrarlı Kayıt Hatası";
            public const string kayitBulunamadiHatasi = "Kayıt Hatası";
            public const string lisansHatasi = "Lisans Hatası";
            public static string sqlHatasi = "SQL Hatası";
            public static string entityValidationError = "Parametre Doğrulama Hatası";
            public const string bagliKayitHatasi = "Silme Hatası";
        }

        #region Global Exceptions

        /// <summary>
        /// Yeni işlem hatası oluşturur.
        /// </summary>
        /// <param name="message">verilecek mesaj girilir.</param>
        /// <param name="code">hata kodu girilir. Default: Codes.islemHatasi</param>
        /// <param name="title">hata basligi girilir. Titles: Codes.islemHatasi</param>
        /// <returns></returns>
        public static OperationException New(string message, string code = Codes.islemHatasi, string title = Titles.islemHatasi)
        {
            return new OperationException(message, code, title);
        }

        /// <summary>
        /// Parametre eksikliği ile ilgili hata mesajı döner.
        /// </summary>
        /// <returns></returns>
        public static OperationException ParametreHatasi(string message = Messages.parametreHatasi)
        {
            return New(message, Codes.parametreHatasi, Titles.parametreHatasi);
        }

        /// <summary>
        /// Kayıt bulunamadı hatası döner.
        /// </summary>
        /// <returns></returns>
        public static OperationException KayitBulunamadiHatasi(string message = Messages.kayitBulunamadiHatasi)
        {
            return New(message, Codes.kayitBulunamadiHatasi, Titles.kayitBulunamadiHatasi);
        }

        #endregion Global Exceptions
    }
}
