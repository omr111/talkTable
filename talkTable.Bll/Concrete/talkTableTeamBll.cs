using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Concrete
{
    public class talkTableTeamBll: ItalkTableTeamBll
    {
        private ItalkTableTeamDal _talkTableTeamDal;
        public talkTableTeamBll(ItalkTableTeamDal talkTableTeamDal)
        {
            _talkTableTeamDal = talkTableTeamDal;
        }
        public bool add(talkTableTeam talkTableTeam)
        {
            return _talkTableTeamDal.Add(talkTableTeam);
        }

        public bool delete(talkTableTeam talkTableTeam)
        {
            return _talkTableTeamDal.Delete(_talkTableTeamDal.getOne(x => x.id == talkTableTeam.id));
        }

        public List<talkTableTeam> getAll()
        {
            return _talkTableTeamDal.listAll();
        }

        public talkTableTeam getOne(int id)
        {
            return _talkTableTeamDal.getOne(x => x.id == id);
        }

        public bool update(talkTableTeam talkTableTeam)
        {
            return _talkTableTeamDal.Update(talkTableTeam);
        }
    }
}
