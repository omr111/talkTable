using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class teamMemberBll: IteamMemberBll
    {
        private IteamMemberDal _teamMemberDal;
        public teamMemberBll(IteamMemberDal teamMemberDal)
        {
            _teamMemberDal = teamMemberDal;
        }
    }
}
