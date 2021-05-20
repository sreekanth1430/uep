using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// EmployeeSkillDTO is to fetch only required properties from employeeskills model
/// </summary>
namespace Casestudy11.DTO
{
    public class EmployeeSkillDTO
    {
        public int pkAuto { get; set; }
        public int primary { get; set; }

        public int empId { get; set; }

        public string? empName { get; set; }

        public int? rating { get; set; }

        public string? hccOrganization { get; set; }

        public string? grade { get; set; }

        public DateTime? lastUpdatedDate { get; set; }

        public DateTime? skillStartDate { get; set; }

        public DateTime? skillEndDate { get; set; }

        public string? group { get; set; }

        public string? skillType { get; set; }

        public string? approvedBy { get; set; }

        public DateTime? approvedDate { get; set; }

        public int SkillId { get; set; }

        public int? approvalStatus { get; set; }
    }
}
