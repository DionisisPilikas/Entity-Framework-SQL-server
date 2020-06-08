using Entities;
using System.Data.Entity;

namespace DataBase
{
    public class SchoolDB : DbContext
    {
        public SchoolDB() : base("ConnectionWithDB") { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Mark> Marks { get; set; }

    }
}
