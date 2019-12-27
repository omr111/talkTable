using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IhowIsWorkBll
    {
        howIsWork getOne(int id);
        bool update(howIsWork howIsWork);
        bool delete(howIsWork howIsWork);
    }
}
