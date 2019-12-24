using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface ItalkTableTeamBll
    {
        List<talkTableTeam> getAll();
        talkTableTeam getOne(int id);
        bool add(talkTableTeam talkTableTeam);
        bool delete(talkTableTeam talkTableTeam);
        bool update(talkTableTeam talkTableTeam);
    }
}
