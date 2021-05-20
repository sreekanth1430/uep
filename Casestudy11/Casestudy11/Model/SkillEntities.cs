using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// models for employeeinfo, employeeskill and skillmaster
/// </summary>
namespace Casestudy11.Model
{
    [Table("SkillMaster")]
    public class SkillMaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "int")]
        public int skillId { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? name { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? skillCatName { get; set; }
    }

    [Table("EmployeeInfo")]
    public class EmployeeInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(TypeName = "int")]
        public int empId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? empName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? empEmailId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? project { get; set; }

        [Column(TypeName = "varchar(100)")]
        public EmployeeInfo pmId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? pmEmailId { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? role { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? grade { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? hccOrganization { get; set; }


    }

    [Table("EmployeeSkills")]
    public class EmployeeSkill
    {
        [Key]
        public int pkAuto { get; set; }
        public int primary { get; set; }

        [Column("empId")]
        public EmployeeInfo empId { get; set; } //ForeignKey

        [Column(TypeName = "varchar(45)")]
        public string? empName { get; set; }

        [Column(TypeName = "int")]
        public int? rating { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? hccOrganization { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? grade { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? lastUpdatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? skillStartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? skillEndDate { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? group { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string? skillType { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string? approvedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? approvedDate { get; set; }

        [Column("skillId")]
        public SkillMaster SkillId { get; set; }

        [Column(TypeName = "int")]
        public int? approvalStatus { get; set; }
    }

}
