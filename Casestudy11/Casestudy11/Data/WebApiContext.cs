using Casestudy11.Model;
using Microsoft.EntityFrameworkCore;
using SkillMgnt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casestudy11.Data
{
    public class WebApiContext : DbContext, ISkillMgntContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<SkillMaster> SkillMaster { get; set; }
        public DbSet<Casestudy11.Model.Login> Login { get; set; }


        public void MarkAsModified(object item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}

