using Casestudy11.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkillMgnt.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unit_SkillMgnt
{
    //public class TestSkillMgntContext : ISkillMgntContext
    //{
    //    public TestSkillMgntContext()
    //    {
    //        this.SkillMaster = new TestSkillMasterDbSet();
    //        this.EmployeeSkill = new TestEmployeeSkillDbSet();
    //        this.EmployeeInfo = new TestEmployeeInfoDbSet();
    //        this.Login = new TestLoginDbSet();
    //    }
    //    public DbSet<SkillMaster> SkillMaster { get; set ; }
    //    public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
    //    public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
    //    public DbSet<Login> Login { get; set; }

    //    public EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public object ToList<TSource>([NotNullAttribute] this IQueryable<TSource> source, CancellationToken cancellationToken = default)
    //    //{
    //    //    return new Object();
    //    //}
    //}
    public class TestSkillMgntContext : DbContext, ISkillMgntContext
    {
        public TestSkillMgntContext()
        {
            this.SkillMaster = new TestSkillMasterDbSet();
            this.EmployeeSkill = new TestEmployeeSkillDbSet();
            this.EmployeeInfo = new TestEmployeeInfoDbSet();
            this.Login = new TestLoginDbSet();
        }
        public DbSet<SkillMaster> SkillMaster { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public DbSet<Login> Login { get; set; }


        public void MarkAsModified(object item)
        {
            //Entry(item).State = EntityState.Modified;
        }

        //public void MarkAsModified(SkillMaster item)
        //{
        //    Entry(item).State = EntityState.Modified;
        //}

        //public void MarkAsModified(EmployeeSkill item)
        //{
        //    Entry(item).State = EntityState.Modified;
        //}
        //public void MarkAsModified(EmployeeInfo item)
        //{
        //    Entry(item).State = EntityState.Modified;
        //}
        //public void MarkAsModified(Login item)
        //{
        //    Entry(item).State = EntityState.Modified;
        //}


        //public EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class
        //{
        //    return new EntityEntry<TEntity>();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            Task<int> task = new Task<int>(() =>
            {
                return 1;
            });

            task.Start();
            return task;
        }

    }
}
