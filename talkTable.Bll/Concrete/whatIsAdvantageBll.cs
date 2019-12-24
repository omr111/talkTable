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
   public class whatIsAdvantageBll: IwhatIsAdvantageBll
    {
        private IwhatIsAdvantageDal _whatIsAdvantageDal;
        public whatIsAdvantageBll(IwhatIsAdvantageDal whatIsAdvantageDal)
        {
            _whatIsAdvantageDal = whatIsAdvantageDal;
        }

        public bool add(whatIsAdvantage whatIsAdvantage)
        {
            return _whatIsAdvantageDal.Add(whatIsAdvantage);
        }

        public bool delete(whatIsAdvantage whatIsAdvantage)
        {
            return _whatIsAdvantageDal.Delete(_whatIsAdvantageDal.getOne(x => x.id == whatIsAdvantage.id));
        }

        public whatIsAdvantage getOne(int id)
        {
            return _whatIsAdvantageDal.getOne(x => x.id == id);
        }

        public bool update(whatIsAdvantage whatIsAdvantage)
        {
            return _whatIsAdvantageDal.Update(whatIsAdvantage);
        }
    }
}
