using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IsiteInformationBll
    {
        siteInformation getOne(int id);
        bool add(siteInformation site);
        bool update(siteInformation site);
    }
}
