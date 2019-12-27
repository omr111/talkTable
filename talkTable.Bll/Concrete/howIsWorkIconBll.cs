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
    public class howIsWorkIconBll: IhowIsWorkIconBll
    {
        private IhowIsWorkIconDal _howIsWorkIconDal;
        public howIsWorkIconBll(IhowIsWorkIconDal howIsWorkIconDal)
        {
            _howIsWorkIconDal =howIsWorkIconDal;
        }
        public bool add(howIsWorkIcon howIsWorkIcon)
        {
            return _howIsWorkIconDal.Add(howIsWorkIcon);
        }

        public bool delete(howIsWorkIcon howIsWorkIcon)
        {
            return _howIsWorkIconDal.Delete(_howIsWorkIconDal.getOne(x => x.id == howIsWorkIcon.id));
        }

        public List<howIsWorkIcon> getAll()
        {
            return _howIsWorkIconDal.listAll();
        }

        public howIsWorkIcon getOne(int id)
        {
            return _howIsWorkIconDal.getOne(x => x.id == id);
        }

        public bool update(howIsWorkIcon howIsWorkIcon)
        {
            return _howIsWorkIconDal.Update(howIsWorkIcon);
        }
    }
}
