using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.CustomValidations;

namespace Entities
{
   public  class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Stream is Required")]
        [Display(Name = "Stream")]
        public string Stream { get; set; }

        [Required(ErrorMessage = "Choose Course Type")]
        [Display(Name = "Course Type")]
        public CourseType CourseType { get; set; }  //enum


        [Display(Name = "Start Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }


        //custom validation ************** Folder-> CustomValidations -> ValidationMethod 
        //Tuitionfees should be 2500
        [CustomValidation(typeof(ValidationMethod), "ValidateGreaterOf2500")]
        [Display(Name = "Tuition Fees")]
        public decimal TuitionFees { get; set; }



        public virtual ICollection<Trainer> Trainers { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        //every course has a list of trainers
        //every course has a list of students
        //every course has a list of assignments
    }
}
