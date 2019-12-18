using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using talkTable.Dal.Abstract;
using talkTable.Entities.Entities;

namespace talkTable.Dal.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        talkTableContext ctx = new talkTableContext();
        public bool Add(T entity)
        {
            ctx.Entry(entity).State = EntityState.Added;
            int result=ctx.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete(T entity)
        {
            ctx.Entry(entity).State = EntityState.Deleted;
            int result = ctx.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }

        public T getOne(Expression<Func<T, bool>> filter)
        {
            return ctx.Set<T>().FirstOrDefault(filter);
        }

        public List<T> listAll(Expression<Func<T, bool>> filter = null)
        {
            return ctx.Set<T>().Where(filter).ToList();
        }

        public bool Update(T entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
            int result = ctx.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
