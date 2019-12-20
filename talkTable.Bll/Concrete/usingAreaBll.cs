using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Concrete
{
    public class usingAreaBll : IusingAreaBll
    {
        IusingAreaDal _usingAreaDal;
        public usingAreaBll(IusingAreaDal usingAreaDal)
        {
            _usingAreaDal = usingAreaDal;
        }
        public bool add(usingArea usingArea)
        {
           return _usingAreaDal.Add(usingArea);
        }

        public bool delete(int id)
        {

           return _usingAreaDal.Delete(_usingAreaDal.getOne(x => x.id == id));
        }

        public usingArea getOne(int id)
        {
            return _usingAreaDal.getOne(x => x.id == id);
        }

        public bool update(usingArea usingArea)
        {
            return _usingAreaDal.Update(usingArea);
        }
    }
}
