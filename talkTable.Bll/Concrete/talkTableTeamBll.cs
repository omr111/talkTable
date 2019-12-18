using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class talkTableTeamBll: ItalkTableTeamBll
    {
        private ItalkTableTeamDal _talkTableTeamDal;
        public talkTableTeamBll(ItalkTableTeamDal talkTableTeamDal)
        {
            _talkTableTeamDal = talkTableTeamDal;
        }
    }
}
