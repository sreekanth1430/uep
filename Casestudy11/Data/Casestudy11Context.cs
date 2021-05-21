using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Casestudy11.Model;

namespace Casestudy11.Data
{
    public class Casestudy11Context : DbContext
    {
        public Casestudy11Context (DbContextOptions<Casestudy11Context> options)
            : base(options)
        {
        }

        public DbSet<Casestudy11.Model.SkillMaster> SkillMaster { get; set; }

        public DbSet<Casestudy11.Model.EmployeeSkill> EmployeeSkill { get; set; }

        public DbSet<Casestudy11.Model.EmployeeInfo> EmployeeInfo { get; set; }

        public DbSet<Casestudy11.Model.empskillsmodel1> empskillsmodel1 { get; set; }

       // public DbSet<Casestudy11.Model.Login> Login { get; set; }
    }
}
