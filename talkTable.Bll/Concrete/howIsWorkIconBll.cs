using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class howIsWorkIconBll: IhowIsWorkIconBll
    {
        private IhowIsWorkIconDal _IhowIsWorkIconDal;
        public howIsWorkIconBll(IhowIsWorkIconDal IhowIsWorkIconDal)
        {
            _IhowIsWorkIconDal = IhowIsWorkIconDal;
        }
    }
}
