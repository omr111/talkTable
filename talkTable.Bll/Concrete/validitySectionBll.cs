using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class validitySectionBll: IvaliditySectionBll
    {
        private IvaliditySectionDal _validitySectionDal;
        public validitySectionBll(IvaliditySectionDal validitySectionDal)
        {
            _validitySectionDal = validitySectionDal;
        }
    }
}
