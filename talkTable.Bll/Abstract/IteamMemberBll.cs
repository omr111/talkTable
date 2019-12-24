using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IteamMemberBll
    {
        List<teamMember> getAll();
        List<teamMember> getAllBytalkTableTeamId(int id);
        teamMember getOne(int id);
        bool add(teamMember teamMember);
        bool delete(teamMember teamMember);
        bool update(teamMember teamMember);
    }
}
