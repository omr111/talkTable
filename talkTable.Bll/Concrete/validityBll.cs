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
    public class validityBll: IvalidityBll
    {
        private IvalidityDal _validityDal;
        public validityBll(IvalidityDal validityDal)
        {
            _validityDal = validityDal;
        }

        public bool add(validity validity)
        {
            return _validityDal.Add(validity);
        }

        public bool delete(validity validity)
        {
            return _validityDal.Delete(validity);
        }

        public List<validity> getAll()
        {
            return _validityDal.listAll();
        }

        public validity getOne(int id)
        {
            return _validityDal.getOne(x => x.id == id);
        }

        public bool update(validity validity)
        {
            return _validityDal.Update(validity);
        }
    }
}
