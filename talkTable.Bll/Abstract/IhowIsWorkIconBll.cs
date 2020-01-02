using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IhowIsWorkIconBll
    {
        List<howIsWorkIcon> getAll();
        List<howIsWorkIcon> getAllByPictureId(int id);
        howIsWorkIcon getOne(int id);
        bool add(howIsWorkIcon howIsWorkIcon);
        bool delete(howIsWorkIcon howIsWorkIcon);
        bool update(howIsWorkIcon howIsWorkIcon);
    }
}
