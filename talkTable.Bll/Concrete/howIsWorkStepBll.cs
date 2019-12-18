using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class howIsWorkStepBll: IhowIsWorkStepBll
    {
        private IhowIsWorkStepDal _howIsWorkStepDal;
        public howIsWorkStepBll(IhowIsWorkStepDal howIsWorkStepDal)
        {
            _howIsWorkStepDal = howIsWorkStepDal;
        }
    }
}
