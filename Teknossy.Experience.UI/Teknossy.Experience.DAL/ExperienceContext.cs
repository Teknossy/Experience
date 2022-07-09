using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teknossy.Experience.Entity.Models.System;

namespace Teknossy.Experience.DAL
{
    public class ExperienceContext : DbContext
    {
        public ExperienceContext(DbContextOptions<ExperienceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ExperienceContext).Assembly);
        }

        #region User

        public DbSet<User> User { get; set; }

        #endregion
    }
}
