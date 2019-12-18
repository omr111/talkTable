using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class sendMailBll: IsendMailBll
    {
        private IsendMailDal _sendMailDal;
        public sendMailBll(IsendMailDal sendMailDal)
        {
            _sendMailDal = sendMailDal;
        }
    }
}
