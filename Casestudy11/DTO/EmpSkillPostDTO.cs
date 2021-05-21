using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// EmpSkillPostDTO is to create enew employee who want to register in skills.
/// employee name and other required properties will fetch the data from employee info model
/// </summary>
namespace Casestudy11.DTO
{
    public class EmpSkillPostDTO
    {
        public string primary { get; set; }

        public string empId { get; set; }


        public string? rating { get; set; }

        public DateTime? skillStartDate { get; set; }

        public DateTime? skillEndDate { get; set; }

        public string? group { get; set; }

        public string? skillType { get; set; }

        public string SkillId { get; set; }

    }
}
