using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key] //Key is used to explicitly state this is the PK, since the usual naming convention doesn't apply.
        [ForeignKey("Instructor")] //Since this is a one-to-zero-or-one relationship, we explicitly state that OfficeAssignment is dependent upon Instructor.
        public int InstructorID { get; set; }

        [StringLength(50), Display(Name = "Office Location")]
        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}