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
    public class teamMemberBll: IteamMemberBll
    {
        private IteamMemberDal _teamMemberDal;
        public teamMemberBll(IteamMemberDal teamMemberDal)
        {
            _teamMemberDal = teamMemberDal;
        }
        public bool add(teamMember teamMember)
        {
            return _teamMemberDal.Add(teamMember);
        }

        public bool delete(teamMember teamMember)
        {
            return _teamMemberDal.Delete(_teamMemberDal.getOne(x => x.id == teamMember.id));
        }

        public List<teamMember> getAll()
        {
            return _teamMemberDal.listAll();
        }
        public bool update(teamMember teamMember)
        {
            return _teamMemberDal.Update(teamMember);
        }
        public List<teamMember> getAllBytalkTableTeamId(int id )
        {
            return _teamMemberDal.listAll(x => x.talkTableTeam.id == id);
        }

        public teamMember getOne(int id)
        {
            return _teamMemberDal.getOne(x => x.id == id);
        }
    }
}
