using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //EF Class

namespace QueryIt
{

    //for demo purposes I have called the file DataAccess and will put many classes in it, normally one class per file
    public class EmployeeDb : DbContext 
    {
        public DbSet<Employee> Employees { get; set; }

    }

    //I can make IRepository a covarent as it accepts type T can only make covarient if it returns type T, so lets make a new interface for this
    public interface IReadOnlyRepository<out T> : IDisposable
    {
        T findById(int id);
        IQueryable<T> FindAll(); //Final all method of type IQueryable as I sure maybe want to run queries on this code
    }

    //Repository interface abstraction of Type T, employee, manager, person etc...
    //this abraction allows the actuall repository to be SQLServer or a file etc...
    //Inherits from IDisposable so it will clean up
    //can use a contravarient here 

    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        //next 2 now moved to IReadOnlyRepository 
        //T findById(int id);
        //IQueryable<T> FindAll(); //Final all method of type IQueryable as I sure maybe want to run queries on this code
        int Commit();

    }

    //this doesn't work for contravarients either as it's inheriting from the read only so create a wrte only IF
    //public interface IRepository<in T> : IReadOnlyRepository<T>,IDisposable
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>, IDisposable
    {


    }

    //now define my sql class which inherits from this interface, I.e. must implement all of the above methods
    //ctrl . on IRepository to create stubs 
    //use a generic constraint where T: class here as T must be a class (reference type) if its a DbSet can use struct to force a value type
    //Also enforce T to implement IEntity which forces an IsValid method
    //class or struct constraint 1st and new() must be last --not used here comment out
    public class SqlReposistory<T> : IRepository<T> where T: class, IEntity//,new()
    {
        //backing variables
        DbContext _ctx;
        DbSet<T> _set; //if I f12 on here it shows my that DbSet has a generic constraint of type

        //constructor
        public SqlReposistory(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }


        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            { 
                _set.Add(newEntity);
            }
        }

        public int Commit()
        {
            return _ctx.SaveChanges(); //returns number of changes made
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public T findById(int id)
        {
            //T entity = new T(); //to do this must have a new constraint
            //if can't find anything return a null ;
            //T entity = null; //can do this for a value type
            //T entity = default(T);//instead normally use the default
            return _set.Find(id);
        }
    }
}
