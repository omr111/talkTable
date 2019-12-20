using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IusingAreaBll
    {
        usingArea getOne(int id);
        bool add(usingArea usingArea);
        bool delete(int id);
        bool update(usingArea usingArea);
    }
}
