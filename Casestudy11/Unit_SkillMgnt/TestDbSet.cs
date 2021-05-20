using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
//using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SkillMgnt.Data
{
    public class TestDbSet<T> : DbSet<T>, IQueryable<T>, IEnumerable<T> where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;
        private readonly IQueryProvider _inner;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();

        }

        public TestDbSet(IQueryProvider inner)
        {
            _inner = inner;
        }

        public override EntityEntry<T> Add(T item)
        {
            _data.Add(item);
            return item as EntityEntry<T>;
        }

        public override EntityEntry<T> Remove(T item)
        {
            _data.Remove(item);
            _data = _data;
            return item as EntityEntry<T>;
        }

        public override EntityEntry<T> Attach(T item)
        {
            _data.Add(item);
            return item as EntityEntry<T>;
        }

        //public override T Create()
        //{
        //    return Activator.CreateInstance<T>();
        //}

        //public override TDerivedEntity Create<TDerivedEntity>()
        //{
        //    return Activator.CreateInstance<TDerivedEntity>();
        //}

        //public override LocalView<T> Local
        //{
        //    get { return new LocalView<T>(_data); }
        //}

        public override LocalView<T> Local
        {
            get { return new LocalView<T>(_data as DbSet<T>); }
        }


        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }



        //internal TestAsyncQueryProvider(IQueryProvider inner)
        //{
        //    _inner = inner;
        //}

    }
}
