using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CmsAPI.Model;

namespace CmsAPI.Data
{
    public class CmsContext : DbContext
    {
        public CmsContext (DbContextOptions<CmsContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<CmsAPI.Model.UserSetup> UserSetup { get; set; }
        public DbSet<CmsAPI.Model.Doctor> Doctor { get; set; }
        public DbSet<CmsAPI.Model.Patient> Patient { get; set; }
        public DbSet<CmsAPI.Model.Schedule> Schedule { get; set; }
    }
}
