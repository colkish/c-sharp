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

    //Repository interface abstraction of Type T, employee, manager, person etc...
    //this abraction allows the actuall repository to be SQLServer or a file etc...
    //Inherits from IDisposable so it will clean up
    public interface IRepository<T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        T findById(int id);
        IQueryable<T> FindAll(); //Final all method of type IQueryable as I sure maybe want to run queries on this code
        int commit();

    }

    //now define my sql class which inherits from this interface, I.e. must implement all of the above methods
    public class SqlReposistory : IRepository<T> //ctrl . to create stubs for this
    {
        public void Add(T newEntity)
        {
            throw new NotImplementedException();
        }

        public int commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T findById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
