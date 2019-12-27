using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IhowIsWorkStepBll
    {
        List<howIsWorkStep> getAll();
        howIsWorkStep getOne(int id);
        bool add(howIsWorkStep howIsWorkStep);
        bool delete(howIsWorkStep howIsWorkStep);
        bool update(howIsWorkStep howIsWorkStep);
    }
}
