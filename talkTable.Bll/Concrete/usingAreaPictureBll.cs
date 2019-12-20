using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Concrete
{
    public class usingAreaPictureBll : IusingAreaPictureBll
    {
        IusingAreaPictureDal _usingAreaPicture;
        public usingAreaPictureBll(IusingAreaPictureDal usingAreaPicture)
        {
            _usingAreaPicture = usingAreaPicture;
        }
        public bool addPicture(usingAreaPicture usingAreaPicture)
        {
            return _usingAreaPicture.Add(usingAreaPicture);
        }

        public bool deletePicture(int id)
        {
            return _usingAreaPicture.Delete(_usingAreaPicture.getOne(x => x.id == id));
        }

        public List<usingAreaPicture> getAll()
        {
            return _usingAreaPicture.listAll();

        }

        public usingAreaPicture getOne(int id)
        {
           return _usingAreaPicture.getOne(x => x.id == id);
        }

        public bool updatePicture(usingAreaPicture usingAreaPicture)
        {
            return _usingAreaPicture.Update(usingAreaPicture);
        }
    }
}
