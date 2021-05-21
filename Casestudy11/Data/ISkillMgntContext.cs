using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkillMgnt.Data
{
    public interface ISkillMgntContext : IDisposable
    {
        public DbSet<Casestudy11.Model.SkillMaster> SkillMaster { get; set; }

        public DbSet<Casestudy11.Model.EmployeeSkill> EmployeeSkill { get; set; }

        public DbSet<Casestudy11.Model.EmployeeInfo> EmployeeInfo { get; set; }

        public DbSet<Casestudy11.Model.Login> Login { get; set; }

        //public EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;

        public void MarkAsModified(object item);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
