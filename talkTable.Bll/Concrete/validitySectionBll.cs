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
    public class validitySectionBll: IvaliditySectionBll
    {
        private IvaliditySectionDal _validitySectionDal;
        public validitySectionBll(IvaliditySectionDal validitySectionDal)
        {
            _validitySectionDal = validitySectionDal;
        }

        public bool add(validitySection validitySection)
        {
            return _validitySectionDal.Add(validitySection);
        }

        public bool delete(validitySection validitySection)
        {
            return _validitySectionDal.Delete(validitySection);
        }

        public List<validitySection> getAll()
        {
            return _validitySectionDal.listAll();
        }

        public List<validitySection> getAllByValidityId(int id)
        {
            return _validitySectionDal.listAll(x => x.validity.id == id);
        }

        public validitySection getOne(int id)
        {
            return _validitySectionDal.getOne(x => x.id == id);
        }

        public validitySection getOneByValidityId(int id)
        {
            return _validitySectionDal.getOne(x => x.validity.id == id);
        }

        public bool update(validitySection validitySection)
        {
            return _validitySectionDal.Update(validitySection);
        }
    }
}
