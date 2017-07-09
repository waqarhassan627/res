using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectWork.Models
{
    [Table("Test")]
    public class TestDTO
    {
        [Key]
        public int TestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Date { get; set; }
        public string TeacherUname { get; set; }
        public int TotalMarks { get; set; }
    }
}