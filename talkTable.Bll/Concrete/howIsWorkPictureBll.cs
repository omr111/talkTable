using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class howIsWorkPictureBll: IhowIsWorkPictureBll
    {
        private IhowIsWorkPictureDal _howIsWorkPictureDal;
        public howIsWorkPictureBll(IhowIsWorkPictureDal howIsWorkPictureDal)
        {
            _howIsWorkPictureDal = howIsWorkPictureDal;
        }
    }
}
