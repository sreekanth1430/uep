using SkillMgnt.Data;
using Casestudy11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unit_SkillMgnt
{
    class TestSkillMasterDbSet : TestDbSet<SkillMaster>
    {
        public override SkillMaster Find(params object[] keyValues)
        {
            return this.SingleOrDefault(SkillMaster => SkillMaster.skillId == (int)keyValues.Single());
        }
    }
}
