using Launchpad.Data;
using Launchpad.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Infrastructure.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        protected readonly LaunchpadDataContext _ctx;

        public SqlRepository() : this(new LaunchpadDataContext())
        {

        }
        public SqlRepository(LaunchpadDataContext ctx)
        {
            _ctx = ctx;
        }

        public virtual IQueryable<T> Get()
        {
            return _ctx.Set<T>();
        }

        public void Remove(T record)
        {
            _ctx.Set<T>().Remove(record);
        }

        public void Remove(int key)
        {
            var found = _ctx.Set<T>().Find(key);
            if (found != null)
            {
                _ctx.Set<T>().Remove(found);
            }
        }

        public virtual T Add(T record)
        {
            _ctx.Set<T>().Add(record);
            return record;
        }

        public virtual T Update(T record, int key)
        {
            if (record == null)
                return null;

            T found = _ctx.Set<T>().Find(key);
            if (found != null)
            {
                _ctx.Entry(found).CurrentValues.SetValues(record);
            }
            return found;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate);
        }

        public bool Commit()
        {
            bool isDone = false;

            try
            {
                _ctx.SaveChanges();
                isDone = true;
            }

            catch (Exception ex)
            {
                throw;
            }
            return isDone;
        }
    }
}
