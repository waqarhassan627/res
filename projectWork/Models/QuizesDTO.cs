using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectWork.Models
{
     [Table("Quizes")]
    public class QuizesDTO
    {
        [Key]
        public int QuizID { get; set; }
        public int UserID { get; set; }
        public bool isTaken { get; set; }
        public int MarksObtained{ get; set; }
        public string ConductDate { get; set; }
        public int TestID { get; set; }
        public int TotalMarks { get; set; }
        public string UserName { get; set; }
    }
}