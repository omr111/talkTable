using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class howIsWorkBll: IhowIsWorkBll
    {
        private IhowIsWorkDal _howIsWorkDal;
        public howIsWorkBll(IhowIsWorkDal howIsWorkDal)
        {
            _howIsWorkDal = howIsWorkDal;
        }
    }
}
