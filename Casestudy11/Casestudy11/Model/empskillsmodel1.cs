using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Casestudy11.Model
{
    /// <summary>
    ///  empskillsmodel1 is to fetch  only data required from employees for 
    ///  approval and rejection for manager model
    /// </summary>
    public class empskillsmodel1
    {
        [Key]
        public int id { get; set; }
        [Column("Empid")]
        public EmployeeInfo Empid { get; set; }

        [Column("skillid")]
        public SkillMaster skillid { get; set; }
        public String Rating { get; set; }
        public DateTime Last_updated_Date { get; set; }
        public DateTime skill_start_date { get; set; }
        public DateTime skill_end_date { get; set; }
        public String group { get; set; }
        public String skilltype { get; set; }
        public String approvedby { get; set; }
        public String approveddate { get; set; }
        public String primary { get; set; }
        public int approval_status { get; set; }
    }
}
