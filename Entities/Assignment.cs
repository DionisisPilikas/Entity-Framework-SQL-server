using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Assignment
    {
  
        public int AssignmentId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Submission Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SubmissionDate { get; set; }

        public int CourseId { get; set; } //foreignKey to Table Course ([Required] 1 to many (relationship)
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }


        //every assignment matches one course
        //every assignment matches many students
        //evere assignment have many markd / per student

    }
}
