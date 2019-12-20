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
    public class siteInformationBll: IsiteInformationBll
    {
        private IsiteInformationDal _siteInformationDal;
        public siteInformationBll(IsiteInformationDal siteInformationDal)
        {
            _siteInformationDal = siteInformationDal;
        }

        public bool add(siteInformation site)
        {
           return _siteInformationDal.Add(site);
        }

        public siteInformation getOne(int id)
        {
            return _siteInformationDal.getOne(x => x.id == id);
        }

        public bool update(siteInformation site)
        {
            return _siteInformationDal.Update(site);
        }
    }
}
