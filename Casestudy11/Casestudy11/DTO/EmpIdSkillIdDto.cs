using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// EmpIdSkillIdDto model which is used to select empid and skillid
///  to delete a perticular employee who already registered with skills
/// </summary>
namespace Casestudy11.DTO
{
    public class EmpIdSkillIdDto
    {
        public int empId { get; set; }
        public int skillId { get; set; }
    }
}
