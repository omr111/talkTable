using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class validityBll: IvalidityBll
    {
        private IvalidityDal _validityDal;
        public validityBll(IvalidityDal validityDal)
        {
            _validityDal = validityDal;
        }
    }
}
