using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class bannerBll: IbannerBll
    {
        private IbannerDal _bannerDal;
        public bannerBll(IbannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }
    }
}
