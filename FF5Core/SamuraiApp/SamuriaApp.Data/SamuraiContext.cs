using Microsoft.EntityFrameworkCore; //Add here to use EF Core after getting the EF Core SQL Server from NuGet Package manager right click on project , NUGet Pckage manager and search for EntityFrameworkCore.SqlServer
                                     //also need to egt the EF Core Tools for migration in this and the UI Project
                                     //Now I get a tools menu, go into NuGet Package Manager, Package Manager console
                                     //put command here (ensure defauilt project is SamuraiApp.Data get-help entityframework
                                     //add-migration init creates me a ..init migration file in the solution...
                                     //use script-migration to create the t-SQL script
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                //Local built in DB
                //            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiAppData");
                optionsBuilder.UseSqlServer("Data source=HSYOLAP02\\SQL2K16; Initial Catalog=SamuraiAppData;trusted_connection=true");

        }

    }
}
