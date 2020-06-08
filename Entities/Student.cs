using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Student
    {
        public int StudentId { get; set; }


        [Required(ErrorMessage = "Your First Name is required")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "We accept only Letters")]  //to mono pou mporei na dexetai einai grammata
        [MaxLength(30, ErrorMessage = "Too many characters for Name Characters exxed 30"),MinLength(4, ErrorMessage = "You should type more than 4 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your Last Name is required")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "We accept only Letters")]  //to mono pou mporei na dexetai einai grammata
        [MaxLength(30, ErrorMessage = "Too many characters for Name Characters exxed 30"), MinLength(4, ErrorMessage = "You should type more than 4 characters")]
        public string LastName { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth  { get; set; }

        [Display(Name = "Upload Image File")]   
        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }


        [Required(ErrorMessage = "Your e-mail is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [NotMapped] //den mpainei sth vash (business Logic)
        public double Age
        {
            get { return DateTime.Now.Year - this.DateOfBirth.Year;}
        }


        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        //every student can take part in many Course 
        //every student can take part in many assignments
        //every student has many Marks (per Assignment)
    }
}
