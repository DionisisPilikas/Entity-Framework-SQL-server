using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace WebApp.Models
{
    public class StatsViewModel
    {
        public int StudentsCount { get; set; }
        public double AgeAverage { get; set; }
    
        public IEnumerable<Student> StudentsWithAgeGreaterThan30 { get; set; }
        public IEnumerable<Student> StudentsWithMarkGreaterThan80 { get; set; }

    }
}