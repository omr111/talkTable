using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace talkTable.Dal.Abstract
{
   public interface IRepositoryBase<T> where T:class
    {
        List<T> listAll(Expression<Func<T, bool>>filter=null);
        T getOne(Expression<Func<T, bool>> filter);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
