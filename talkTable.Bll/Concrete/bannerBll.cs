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
    public class bannerBll: IbannerBll
    {
        private IbannerDal _bannerDal;
        public bannerBll(IbannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public bool add(banner banner)
        {
            return _bannerDal.Add(banner);
        }

        public bool delete(banner banner)
        {
            return _bannerDal.Delete(banner);
        }

        public List<banner> getAll()
        {
            return _bannerDal.listAll();
        }

        public banner getOne(int id)
        {
            return _bannerDal.getOne(x=>x.id==id);
        }
        public bool update(banner banner)
        {
            return _bannerDal.Update(banner);
        }
    }
}
