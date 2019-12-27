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
    public class howIsWorkPictureBll: IhowIsWorkPictureBll
    {
        private IhowIsWorkPictureDal _howIsWorkPictureDal;
        public howIsWorkPictureBll(IhowIsWorkPictureDal howIsWorkPictureDal)
        {
            _howIsWorkPictureDal = howIsWorkPictureDal;
        }
        public bool add(howIsWorkPicture howIsWorkPicture)
        {
            return _howIsWorkPictureDal.Add(howIsWorkPicture);
        }

        public bool delete(howIsWorkPicture howIsWorkPicture)
        {
            return _howIsWorkPictureDal.Delete(_howIsWorkPictureDal.getOne(x => x.id == howIsWorkPicture.id));
        }

        public List<howIsWorkPicture> getAll()
        {
            return _howIsWorkPictureDal.listAll();
        }

        public howIsWorkPicture getOne(int id)
        {
            return _howIsWorkPictureDal.getOne(x => x.id == id);
        }

        public bool update(howIsWorkPicture howIsWorkPicture)
        {
            return _howIsWorkPictureDal.Update(howIsWorkPicture);
        }
    }
}
