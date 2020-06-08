using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;
using Services;

namespace WebApp.Models
{
    public class CourseTrainers
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }

        IRepository<Trainer> trainerRepository;
        IRepository<Course> courseRepository;
        public CourseTrainers(IRepository<Trainer> trainerRepository, IRepository<Course> courseRepository)
        {
            this.trainerRepository = trainerRepository;
            this.courseRepository = courseRepository;
        }

        public CourseTrainers()
        {
            trainerRepository = new RepositoryClass<Trainer>();
            courseRepository = new RepositoryClass<Course>();
            Courses = courseRepository.GetAll();
            Trainers = trainerRepository.GetAll();
        }

    }
}