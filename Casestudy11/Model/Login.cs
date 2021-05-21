using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Casestudy11.Model
{
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar(10)")]
        public string empid { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string pass { get; set; }
    }
}
