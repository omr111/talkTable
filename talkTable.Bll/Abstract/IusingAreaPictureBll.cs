using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
   public interface IusingAreaPictureBll
    {
        List<usingAreaPicture> getAll();
        usingAreaPicture getOne(int id);
        bool addPicture(usingAreaPicture usingAreaPicture);
        bool deletePicture(int id);
        bool updatePicture(usingAreaPicture usingAreaPicture);
    }
}
