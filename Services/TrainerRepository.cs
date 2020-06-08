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
    public class TrainerRepository
    {
        SchoolDB db = new SchoolDB();

        public IEnumerable<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }

        public Trainer GetById(int? id)
        {
            return db.Trainers.Find(id);
        }

        public void Insert(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Added;
            db.SaveChanges();
        }
        public void Update(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Trainer trainer)
        {
            db.Entry(trainer).State = EntityState.Deleted;
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
