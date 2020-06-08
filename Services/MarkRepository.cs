using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataBase;
using System.Data.Entity;

namespace Services
{
   public class MarkRepository
    {
        SchoolDB db = new SchoolDB();

        public IEnumerable<Mark> GetAll()
        {
            return db.Marks.ToList();
        }

        public Mark GetById(int? id)
        {
            return db.Marks.Find(id);
        }

        public void Insert(Mark mark)
        {
            db.Entry(mark).State = EntityState.Added;
            db.SaveChanges();
        }
        public void Update(Mark mark)
        {
            db.Entry(mark).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Mark mark)
        {
            db.Entry(mark).State = EntityState.Deleted;
            db.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
