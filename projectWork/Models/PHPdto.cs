using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectWork.Models
{
    [Table("PHP")]
    public class PHPdto
    {
        [Key]
        public int StID { get; set; }
        public string Statement { get; set; }
        public string OptA { get; set; }
        public string OptB { get; set; }
        public string OptC { get; set; }
        public string OptD { get; set; }
        public string CorrectOpt { get; set; }
    }
}