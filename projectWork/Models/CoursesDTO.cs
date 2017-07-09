using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectWork.Models
{
    [Table("Courses")]
    public class CoursesDTO
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseFee { get; set; }
        public int UserID { get; set; }
        public bool isTaken { get; set; }
        public int ObtainedMarks { get; set; }
        public string grade { get; set; }
    }
}