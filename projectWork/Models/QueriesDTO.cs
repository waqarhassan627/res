using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectWork.Models
{
    [Table("Queries")]
    public class QueriesDTO
    {
        [Key]
        public int QueryID { get; set; }
        public string FullName { get; set; }
        public string msg{ get; set; }
        public string Email{ get; set; }
        public bool isAttended { get; set; }
    }
}