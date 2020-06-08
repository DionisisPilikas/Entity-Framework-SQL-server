using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "Your First Name is required")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "We accept only Letters")]  //to mono pou mporei na dexetai einai grammata
        [MaxLength(30, ErrorMessage = "Too many characters for Name Characters exxed 30"), MinLength(4, ErrorMessage = "You should type more than 4 characters")]


        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your Last Name is required")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "We accept only Letters")]  //to mono pou mporei na dexetai einai grammata
        [MaxLength(30, ErrorMessage = "Too many characters for Name Characters exxed 30"), MinLength(4, ErrorMessage = "You should type more than 4 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your Subject is required")]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Upload Image File")]
        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        [Display(Name = "Video URL")]
        [DataType(DataType.Url)]
        public string VideoUrl { get; set; }

        [Required(ErrorMessage = "Your e-mail is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        //every trainer works at many courses
    }
}
