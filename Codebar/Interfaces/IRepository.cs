using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Domain.Interfaces
{
  public  interface IRepository<T> where T : class
    {
      IQueryable<T> Get();
      T Add(T record);
      T Update(T record, int key);

      void Remove(T record);
      void Remove(int key);

      bool Commit();
      //IQueryable<T> FindUserid(Expression<Func<T, bool>> predicate);
      IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
