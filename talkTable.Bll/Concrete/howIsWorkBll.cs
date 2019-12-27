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
    public class howIsWorkBll: IhowIsWorkBll
    {
        private IhowIsWorkDal _howIsWorkDal;
        public howIsWorkBll(IhowIsWorkDal howIsWorkDal)
        {
            _howIsWorkDal = howIsWorkDal;
        }

        public bool update(howIsWork howIsWork)
        {
            return _howIsWorkDal.Update(howIsWork);
        }

        public bool delete(howIsWork howIsWork)
        {
            return _howIsWorkDal.Delete(howIsWork);
        }

        public List<howIsWork> getAll()
        {
            return _howIsWorkDal.listAll();
        }

        public howIsWork getOne(int id)
        {
            return _howIsWorkDal.getOne(x => x.id == id);
        }
    }
}
