using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Entities;
using Services;


namespace ConApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            StudentRepository st = new StudentRepository();
            var students = st.GetAll();
            //foreach (var student in students)
            //{
            //    foreach (var course in student.Courses.Where(x => x.Stream.Contains("#")).Where(x=>x.CourseType==CourseType.PartTime))
            //    {                                 
            //        Console.WriteLine(student.FirstName);
            //    }
            //}
            //foreach (var student in students)
            //{
            //    foreach (var mark in student.Marks.Where(x => x.Assignment.Description.Contains("TEA")))
            //    {
            //        Console.WriteLine(student.Marks.Max(x => x.MarkValue));
            //    }
            //}
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName);

                foreach(var asig in student.Assignments)
                {
                    Console.WriteLine(asig.Description);
                }
            }


                Console.ReadKey();
        }
    }
}
