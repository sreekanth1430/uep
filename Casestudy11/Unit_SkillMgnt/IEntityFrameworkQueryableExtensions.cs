using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unit_SkillMgnt
{
    public interface IEntityFrameworkQueryableExtensions<T>
    {
        public List<T> ToListAsync();

    }
}
