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
        public DbSet<UserSetup> UserSetup { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
    }
}
