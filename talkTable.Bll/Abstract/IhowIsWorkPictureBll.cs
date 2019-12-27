using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IhowIsWorkPictureBll
    {
        List<howIsWorkPicture> getAll();
        howIsWorkPicture getOne(int id);
        bool add(howIsWorkPicture howIsWorkPicture);
        bool delete(howIsWorkPicture howIsWorkPicture);
        bool update(howIsWorkPicture howIsWorkPicture);
    }
}
