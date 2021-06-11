﻿using Microsoft.EntityFrameworkCore; //Add here to use EF Core after getting the EF Core SQL Server from NuGet Package manager right click on project , NUGet Pckage manager and search for EntityFrameworkCore.SqlServer
                                     //also need to egt the EF Core Tools for migration in this and the UI Project
                                     //Now I get a tools menu, go into NuGet Package Manager, Package Manager console
                                     //put command here (ensure defauilt project is SamuraiApp.Data get-help entityframework
                                     //add-migration init creates me a ..init migration file in the solution...
                                     //use script-migration to create the t-SQL script
                                     //use update-database to apply the scrip to the DB !
                                     //add-migration manytomanysimple creates a script after 
                                     //use update-database to apply manytomanysimple to the DB !
                                     //use add-migration MtoMpayload to create script after adding joinded date to abttleSamurai and overriding the method OnModelCreating
                                     //use get-migration to see a list of migrations and their staus
using SamuraiApp.Domain; //need to use this to access Samurai class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext //inherit from DBcontext class in the EF
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Local built in DB
            //            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiAppData");
            optionsBuilder.UseSqlServer("Data source=HSYOLAP02\\SQL2K16; Initial Catalog=SamuraiAppData;trusted_connection=true");

        }
        //lets override the migrtion and provide details of the new DateJoined property we have added to the class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>
                    (bs => bs.HasOne<Battle>().WithMany(),
                        bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.DateJoined) //I only add this and the next line cos I want to add a default
                .HasDefaultValueSql("getdate()");
        }
    }
}
