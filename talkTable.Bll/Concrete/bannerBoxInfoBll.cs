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
    public class bannerBoxInfoBll: IbannerBoxInfoBll
    {
        private IbannerBoxInfoDal _bannerBoxInfoDal;
        public bannerBoxInfoBll(IbannerBoxInfoDal bannerBoxInfoDal)
        {
            _bannerBoxInfoDal = bannerBoxInfoDal;
        }
        public bool add(bannerBoxInfo bannerBoxInfo)
        {
            return _bannerBoxInfoDal.Add(bannerBoxInfo);
        }

        public bool delete(bannerBoxInfo bannerBoxInfo)
        {
            return _bannerBoxInfoDal.Delete(bannerBoxInfo);
        }

        public List<bannerBoxInfo> getAll()
        {
            return _bannerBoxInfoDal.listAll();
        }

        public List<bannerBoxInfo> getAllByBannerId(int id)
        {
            return _bannerBoxInfoDal.listAll(x => x.bannerId == id);
        }

        public bannerBoxInfo getOne(int id)
        {
            return _bannerBoxInfoDal.getOne(x => x.id == id);
        }

        public bannerBoxInfo getOneByBannerId(int id)
        {
            return _bannerBoxInfoDal.getOne(x => x.bannerId == id);
        }

        public bool update(bannerBoxInfo bannerBoxInfo)
        {
            return _bannerBoxInfoDal.Update(bannerBoxInfo);
        }
    }
}
