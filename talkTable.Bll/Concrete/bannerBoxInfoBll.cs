using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class bannerBoxInfoBll: IbannerBoxInfoBll
    {
        private IbannerBoxInfoDal _bannerBoxInfoDal;
        public bannerBoxInfoBll(IbannerBoxInfoDal bannerBoxInfoDal)
        {
            _bannerBoxInfoDal = bannerBoxInfoDal;
        }
    }
}
