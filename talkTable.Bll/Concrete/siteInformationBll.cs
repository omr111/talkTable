using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class siteInformationBll: IsiteInformationBll
    {
        private IsiteInformationDal _siteInformationDal;
        public siteInformationBll(IsiteInformationDal siteInformationDal)
        {
            _siteInformationDal = siteInformationDal;
        }
    }
}
