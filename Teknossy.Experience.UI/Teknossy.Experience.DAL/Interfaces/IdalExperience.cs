using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.DAL.DataAccess.User;

namespace Teknossy.Experience.DAL.Interfaces
{
    public interface IdalExperience
    {
        IDbContextTransaction OpenTransaction();

        #region User

        dalUser dalUser { get; }

        #endregion
    }
}
