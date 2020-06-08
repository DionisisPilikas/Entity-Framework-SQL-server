using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Mark
    {
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }
      
        [Key, Column(Order = 2)]
        public int AssignmentId { get; set; }
 

        [Display(Name = "Mark")]
        public double? MarkValue{ get; set; }


        public virtual Student Student { get; set; }
        public virtual Assignment Assignment { get; set; }

        //Every Mark matces in a student per course
    }
}
