using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IareaInfoBll
    {
        List<areaInfo> getAll();
        areaInfo getOne(int id);
        bool add(areaInfo areaInfo);
        bool delete(areaInfo areaInfo);
    }
}
