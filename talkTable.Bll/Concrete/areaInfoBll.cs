using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class areaInfoBll: IareaInfoBll
    {
        private IareaInfoDal _areaInfoDal;
        public areaInfoBll(IareaInfoDal areaInfoDal)
        {
            _areaInfoDal = areaInfoDal;
        }
    }
}
