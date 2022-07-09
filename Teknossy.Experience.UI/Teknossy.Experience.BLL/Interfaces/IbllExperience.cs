using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.BLL.Logics.System;

namespace Teknossy.Experience.BLL.Interfaces
{
    public interface IbllExperience
    {
        IDbContextTransaction OpenTransaction();

        #region User

        bllUser bllUser { get; }

        #endregion
    }
}
