using SkillMgnt.Data;
using Casestudy11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_SkillMgnt
{
    class TestEmployeeInfoDbSet : TestDbSet<EmployeeInfo>
    {
        public override EmployeeInfo Find(params object[] keyValues)
        {
            return this.SingleOrDefault(EmployeeInfo => EmployeeInfo.empId == (int)keyValues.Single());
        }
    }
}
