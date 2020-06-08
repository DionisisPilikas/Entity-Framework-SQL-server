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





    public class StudentRepository
    {
        SchoolDB db = new SchoolDB();

        public IEnumerable<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetById(int? id)
        {
            return db.Students.Find(id);
        }

        public void Insert(Student student, IEnumerable<int> AllCoursesIds)
        {
            db.Students.Attach(student); //Anagnosi  Diabasa tou student

            db.Entry(student).Collection("Courses").Load(); //  Fortosa apo to stunent ta courses
            student.Courses.Clear();  //ta katharizw
            db.SaveChanges();
            if (!(AllCoursesIds == null))
            {
                foreach (var id in AllCoursesIds)
                {
                  
                    Course course = db.Courses.Find(id);
                    if (course != null)
                    {
                        student.Courses.Add(course);
                    }
                }
                //db.SaveChanges();
            }

            db.Entry(student).State = EntityState.Added;
            db.SaveChanges();
        }


        public void Update(Student student, IEnumerable<int> AllCoursesIds)
        {

            if (!(AllCoursesIds == null))
            {
                db.Students.Attach(student);
                db.Entry(student).Collection("Courses").Load();
                student.Courses.Clear();
                foreach (var id in AllCoursesIds)
                {
 
                    Course course = db.Courses.Find(id);
                    if (course != null)
                    {
                        student.Courses.Add(course);
                        

                    }
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            { 
            db.Entry(student).State = EntityState.Modified;
             db.SaveChanges();
            }
           
        }
        public void Delete(Student student)
        {
            db.Entry(student).State = EntityState.Deleted;
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
