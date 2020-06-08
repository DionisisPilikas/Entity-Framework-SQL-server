using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Services
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByEntity(Expression<Func<T, bool>> where);
        T GetById(int? id);
        void Insert(T entity);
        //void InsertManyToMany(T entity, IEnumerable<object> listOfIds, string navigationProperty);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application