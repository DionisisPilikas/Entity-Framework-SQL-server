using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using Services;

namespace WebApp.Models
{
    public class StudentCourseAssignment
    {

        IRepository<Student> studentRepository;
        IRepository<Course> courseRepository;       
        IRepository<Assignment> assignmentRepository;
        IRepository<Mark> markRepository;

        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Assignment> Assignments { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
        public StudentCourseAssignment(IRepository<Student> studentRepository, IRepository<Course> courseRepository, IRepository<Assignment> assignmentRepository, IRepository<Mark> markRepository)
        {
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            this.assignmentRepository = assignmentRepository;
            this.markRepository = markRepository;
        }
        public StudentCourseAssignment()
        {
            studentRepository = new RepositoryClass<Student>();
            courseRepository = new RepositoryClass<Course>();
            assignmentRepository = new RepositoryClass<Assignment>();
            markRepository = new RepositoryClass<Mark>();

            Students = studentRepository.GetAll();
            Courses = courseRepository.GetAll();
            Assignments = assignmentRepository.GetAll();
            Marks = markRepository.GetAll();         
        }
    }
}