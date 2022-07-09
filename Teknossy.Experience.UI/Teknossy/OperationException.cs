using System;

namespace Teknossy
{
    public class OperationException : Exception
    {
        public string MessageCode { get; private set; }

        public string MessageDetail { get; private set; }

        public string MessageTitle { get; private set; }

        public OperationException(string errorMessage, string errorCode, string errorTitle)
            : base(errorMessage)
        {
            MessageCode = errorCode;
            MessageTitle = errorTitle;
        }

        public OperationException(string errorMessage, string errorCode)
            : base(errorMessage)
        {
            MessageCode = errorCode;
            MessageTitle = "İşlem Hatası!";
        }

        public OperationException(string errorMessage)
            : base(errorMessage)
        {
            MessageCode = "E1";
            MessageTitle = "İşlem Hatası!";
        }

        public OperationException(Exception ex)
            : base("İşleminiz gerçekleştirilemedi!")
        {
            MessageCode = "E1";
            MessageTitle = "İşlem Hatası!";
        }

        public OperationException(string errorMessage, Exception ex) :
            base(errorMessage, ex)
        {
            Init();
        }

        public void Init()
        {
            var ex = (Exception)this;

            if (this.InnerException != null)
                ex = this.InnerException;

            var exTypeName = ex.GetType().Name;

            if (ex.InnerException != null)
                exTypeName = base.InnerException.GetType().Name;

            if (exTypeName == "SqlException")
            {
                this.MessageCode = Exceptions.Codes.sqlHatasi;
                this.MessageTitle = Exceptions.Titles.sqlHatasi;
            }
            else if (exTypeName == "DbEntityValidationException")
            {
                this.MessageCode = Exceptions.Codes.sqlHatasi;
                this.MessageTitle = Exceptions.Titles.sqlHatasi;
            }
            else if (exTypeName == "OperationException")
            {
                var exOperation = (OperationException)ex;
                this.MessageCode = exOperation.MessageCode;
                this.MessageTitle = exOperation.MessageTitle;
            }
            else
            {
                this.MessageCode = exTypeName;
                this.MessageTitle = "Beklenmeyen Hata";
            }
        }
    }
}
