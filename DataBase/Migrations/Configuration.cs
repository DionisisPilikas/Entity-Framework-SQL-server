namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities;
    using DataBase;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBase.SchoolDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataBase.SchoolDB context)
        {
            //=====================create Course
            Course c1 = new Course(){Title = "CB9",Stream = "C#", CourseType = CourseType.FullTime,
                StartDate = new DateTime(2020, 1, 20),EndDate = new DateTime(2020, 3, 20), TuitionFees = 2500M};
            Course c2 = new Course(){Title = "CB9",Stream = "C#", CourseType = CourseType.PartTime,
                StartDate = new DateTime(2020, 1, 20),EndDate = new DateTime(2020, 6, 20), TuitionFees = 2500M};
            Course c3 = new Course(){Title = "CB9",Stream = "JAVA", CourseType = CourseType.FullTime,
                StartDate = new DateTime(2020, 1, 20),EndDate = new DateTime(2020, 3, 20), TuitionFees = 2500M};
            Course c4 = new Course(){Title = "CB9",Stream = "JAVA", CourseType = CourseType.PartTime,
                StartDate = new DateTime(2020, 1, 20),EndDate = new DateTime(2020, 6, 20), TuitionFees = 2500M};
            //=====================create Student
            Student s1 = new Student()
            {FirstName = "DIONYSIOS",LastName = "PILIKAS", DateOfBirth = new DateTime(1984, 3, 27),PhotoUrl = "/Content/Images/PILIKAS-DIONYSIOS.jpg",
                Email = "dio@gmail.com"};
            Student s2 = new Student()
            {FirstName = "DIMITRIS",LastName = "PAPADOPOULOS", DateOfBirth = new DateTime(1986, 5, 23),PhotoUrl = "/Content/Images/DIMITRIS-PAPADOPOULOS.jpg",
                Email = "jim@gmail.com"};
            Student s3 = new Student()
            {FirstName = "GEORGE",LastName = "GEORGEIOY", DateOfBirth = new DateTime(1990, 2, 25),PhotoUrl = "/Content/Images/GEORGE-GEORGEIOY.jpg",
                Email = "Geo@gmail.com"};
            Student s4 = new Student()
            {FirstName = "ANNA",LastName = "NIKOLAOY", DateOfBirth = new DateTime(1985, 6, 4),PhotoUrl = "/Content/Images/ANNA-NIKOLAOY.jpg",
                Email = "anna@gmail.com"};
            Student s5 = new Student()
            {FirstName = "KOSTAS",LastName = "NIKOY", DateOfBirth = new DateTime(1989, 5, 28),PhotoUrl = "/Content/Images/KOSTAS-NIKOY.jpg",
                Email = "kost@gmail.com"};
            Student s6 = new Student()
            {FirstName = "PAUL",LastName = "ANAGNOSTOY", DateOfBirth = new DateTime(1991, 2, 25),PhotoUrl = "/Content/Images/PAUL-ANAGNOSTOY.jpg",
                Email = "paul@gmail.com"};
            Student s7 = new Student()
            {FirstName = "MARIA",LastName = "BASILEIOY", DateOfBirth = new DateTime(1987, 5, 21),PhotoUrl = "/Content/Images/MARIA-BASILEIOY.jpg",
                Email = "mvas@gmail.com"};
            Student s8 = new Student()
            {FirstName = "TASOS",LastName = "PAPAGEORGEIOY", DateOfBirth = new DateTime(1990, 2, 26),PhotoUrl = "/Content/Images/TASOS-PAPAGEORGEIOY.jpg",
                Email = "tpap@gmail.com"};

            //=============================create Assignment
            Assignment a1 = new Assignment()
            {Description = "INDIVIDUAL C#-FULL",SubmissionDate = new DateTime(2020, 2, 1)};
            Assignment a2 = new Assignment()
            { Description = "TEAM C#-FULL", SubmissionDate = new DateTime(2020, 3, 15)};
            Assignment a3 = new Assignment()
            { Description = "INDIVIDUAL C#-PART", SubmissionDate = new DateTime(2020, 3, 1)};
            Assignment a4 = new Assignment()
            { Description = "TEAM C#-PART", SubmissionDate = new DateTime(2020, 6, 15)};
            Assignment a5 = new Assignment()
            { Description = "INDIVIDUAL JAVA-FULL", SubmissionDate = new DateTime(2020, 2, 1)};
            Assignment a6 = new Assignment()
            { Description = "TEAM JAVA-FULL", SubmissionDate = new DateTime(2020, 3, 15)};
            Assignment a7 = new Assignment()
            { Description = "INDIVIDUAL JAVA-PART", SubmissionDate = new DateTime(2020, 3, 1)};
            Assignment a8 = new Assignment()
            { Description = "TEAM JAVA-PART", SubmissionDate = new DateTime(2020, 6, 15)};

            //=============================create Trainer
            Trainer t1 = new Trainer()
            {FirstName = "HECTOR", LastName = "GKATSIOS",PhotoUrl = "/Content/Images/HECTOR-GKATSIOS.jpg",Subject="C#", VideoUrl= "#",
                Email="hec@gmail.com"};
            Trainer t2 = new Trainer()
            {FirstName = "GIORGOS", LastName = "PASPARAKIS",PhotoUrl = "/Content/Images/GIORGOS-PASPARAKIS.jpg", Subject="JAVA", VideoUrl= "#",
                Email="geo@gmail.com"};
            Trainer t3 = new Trainer()
            {FirstName = "VYRONAS", LastName = "VASILIADIS",PhotoUrl = "/Content/Images/VYRONAS-VASILIADIS.jpg", Subject="SQL", VideoUrl= "#",
                Email="vyr@gmail.com"};
            Trainer t4 = new Trainer()
            {FirstName = "KOSTAS", LastName = "STROGKYLOS",PhotoUrl = "/Content/Images/KOSTAS-STROGKYLOS.jpg", Subject="SQL", VideoUrl= "#",
                Email="min@gmail.com"};
            Trainer t5 = new Trainer()
            {FirstName = "AGGELOS", LastName = "NIKOLAOY", PhotoUrl = "/Content/Images/non-image.jpg", Subject = "FRONT-END", VideoUrl = "#",
                Email = "min@gmail.com"
            };
            Trainer t6 = new Trainer()
            {FirstName = "NIKOS", LastName = "PAPADOPOYLOS", PhotoUrl = "/Content/Images/non-image.jpg", Subject = "FRONT-END", VideoUrl = "#",
                Email = "min@gmail.com"
            };



            c1.Students = new List<Student>() { s1, s2 };
            c2.Students = new List<Student>() { s3, s4 };
            c3.Students = new List<Student>() { s5, s6 };
            c4.Students = new List<Student>() { s7, s8 };

            c1.Assignments = new List<Assignment>() { a1,a2 };
            c2.Assignments = new List<Assignment>() { a3,a4 };
            c3.Assignments = new List<Assignment>() { a5,a6 };
            c4.Assignments = new List<Assignment>() { a7,a8 };

            s1.Assignments = new List<Assignment>() { a1, a2 };
            s2.Assignments = new List<Assignment>() { a1, a2 };
            s3.Assignments = new List<Assignment>() { a3, a4 };
            s4.Assignments = new List<Assignment>() { a3, a4 };
            s5.Assignments = new List<Assignment>() { a5, a6 };
            s6.Assignments = new List<Assignment>() { a5, a6 };
            s7.Assignments = new List<Assignment>() { a7, a8 };
            s8.Assignments = new List<Assignment>() { a7, a8 };



            t1.Courses = new List<Course>() { c1,c2 };
            t2.Courses = new List<Course>() { c3,c4 };
            t3.Courses = new List<Course>() { c1,c2 };
            t4.Courses = new List<Course>() { c3,c4 };
            t4.Courses = new List<Course>() { c1,c2 };
            t4.Courses = new List<Course>() { c3,c4 };
            t5.Courses = new List<Course>() { c2, c4 };
            t6.Courses = new List<Course>() { c2, c4 };

            s1.Marks = new List<Mark>() {new Mark(){Student= s1,Assignment = a1,MarkValue = 85 },
                new Mark() { Student = s1, Assignment = a2, MarkValue = 90 } };

            s2.Marks = new List<Mark>() { new Mark() { Student = s2, Assignment = a1, MarkValue = 80 },
                new Mark() { Student = s2, Assignment = a2, MarkValue = 95 } };

            s3.Marks = new List<Mark>() { new Mark() { Student = s3, Assignment = a3, MarkValue = 70 },
                new Mark() { Student = s3, Assignment = a4, MarkValue = 92 } };

            s4.Marks = new List<Mark>() { new Mark() { Student = s4, Assignment = a3, MarkValue = 76 },
                new Mark() { Student = s4, Assignment = a4, MarkValue = 97 } };

            s5.Marks = new List<Mark>() { new Mark() { Student = s5, Assignment = a5, MarkValue = 75 },
                new Mark() { Student = s5, Assignment = a6, MarkValue = 90 } };

            s6.Marks = new List<Mark>() { new Mark() { Student = s6, Assignment = a5, MarkValue = 74 },
                new Mark() { Student = s6, Assignment = a6, MarkValue = 82 } };

            s7.Marks = new List<Mark>() { new Mark() { Student = s7, Assignment = a7, MarkValue = 85 },
                new Mark() { Student = s7, Assignment = a8, MarkValue = 75 } };

            s8.Marks = new List<Mark>() { new Mark() { Student = s8, Assignment = a7, MarkValue = 88 },
                new Mark() { Student = s8, Assignment = a8, MarkValue = 72 } };

            context.Courses.AddOrUpdate(x => x.Title, c1, c2, c3, c4);
            context.Students.AddOrUpdate(x => x.LastName, s1, s2, s3, s4, s5, s6, s7, s8);
            //context.Assignments.AddOrUpdate(x => x.Description, a1, a2, a3, a4, a5, a6, a7, a8);
            context.Trainers.AddOrUpdate(x => x.LastName, t1, t2, t3, t4, t5, t6);
            context.SaveChanges();

        }
    }
}
