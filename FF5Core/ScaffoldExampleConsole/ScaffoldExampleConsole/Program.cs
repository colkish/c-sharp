using System;

/*
 add nuget for EF SQL Server and EF Tools then in NUget Package manager run this to reverse engineer a db:
 scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Data Source = HSYOLAP02\SQL2K16; Initial Catalog = SamuraiAppData; Integrated Security=True"
 */

namespace ScaffoldExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
