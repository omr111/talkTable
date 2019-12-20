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
    public class areaInfoBll: IareaInfoBll
    {
        private IareaInfoDal _areaInfoDal;
        public areaInfoBll(IareaInfoDal areaInfoDal)
        {
            _areaInfoDal = areaInfoDal;
        }

        public bool add(areaInfo areaInfo)
        {
            return _areaInfoDal.Add(areaInfo);
        }

        public bool delete(areaInfo areaInfo)
        {
            return _areaInfoDal.Delete(_areaInfoDal.getOne(x => x.id == areaInfo.id));
        }

        public List<areaInfo> getAll()
        {
            return _areaInfoDal.listAll();
        }

        public areaInfo getOne(int id)
        {
            return _areaInfoDal.getOne(x => x.id == id);
        }
    }
}
