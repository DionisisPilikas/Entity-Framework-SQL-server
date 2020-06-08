using System;
using System.Collections.Generic;
using DataBase;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;

namespace Services
{
    public class RepositoryClass<T> : IRepository<T> where T : class
    {
        private SchoolDB _context = null;
        public DbSet<T> table;
        public RepositoryClass()
        {
            this._context = new SchoolDB();
            this.table = _context.Set<T>();
        }

        public RepositoryClass(SchoolDB _context)
        {
            this._context = _context;

        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(int? id)
        {
            return table.Find(id);
        }
        public IEnumerable<T> FindByEntity(Expression<Func<T, bool>> where)
        {
            return table.Where(where);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        //public void InsertManyTomany(T entity, IEnumerable<object> updatedSet, string navigationProperty, Type propertyType)
        //{
        //    table.Attach(entity); //Anagnwsh tou entity 
        //    _context.Entry(entity).Collection("navigationProperty").Load(); //  Fortosa apo to stunent ta courses
        //    student.Courses.Clear();  //ta katharizw
        //    db.SaveChanges();
        //    Type type;
        //    if (!(AllCoursesIds == null))
        //    {
        //        foreach (var id in updatedSet)
        //        { 
        //            Type type = updatedSet
        //            .Select(obj => (int)obj
        //                .GetType()
        //                .GetProperty("Id")
        //                .GetValue(obj, null))
        //            .Select(value => table.Set(type).Find(value))
        //        {              
        //    }
        //    table.E
        //        //foreach (var id in AllCoursesIds)
        //        //{
        //        //    Course course = db.Courses.Find(id);
        //        //    if (course != null)
        //        //    {
        //        //        student.Courses.Add(course);
        //        //    }



        //    db.Entry(student).State = EntityState.Added;
        //    db.SaveChanges();

        //}
  
        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }
        public void Save() 
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
