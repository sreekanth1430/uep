using Microsoft.EntityFrameworkCore;
using SkillMgnt.Data;
using Casestudy11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unit_SkillMgnt
{
    class TestEmployeeSkillDbSet : TestDbSet<EmployeeSkill>
    {
        public override EmployeeSkill Find(params object[] keyValues)
        {
            return this.SingleOrDefault(EmployeeSkill => EmployeeSkill.pkAuto == (int)keyValues.Single());
        }

    }
}
