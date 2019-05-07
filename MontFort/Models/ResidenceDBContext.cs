using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MontFort.Migrations;


namespace MontFort.Models
{
    public class ResidenceDBContext : DbContext
    {
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ResidenceDBContext, Configuration>());
        }
    }
}