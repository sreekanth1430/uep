using Casestudy11.Model;
using SkillMgnt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unit_SkillMgnt
{
    class TestLoginDbSet : TestDbSet<Login>
    {
        public override Login Find(params object[] keyValues)
        {
            return this.SingleOrDefault(Login => Login.empid == (string)keyValues.Single());
        }
    }
}
