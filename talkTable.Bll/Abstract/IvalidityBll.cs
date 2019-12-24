using System.Collections.Generic;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IvalidityBll
    {
        List<validity> getAll();
        validity getOne(int id);
        bool add(validity validity);
        bool delete(validity validity);
        bool update(validity validity);
    }
}
