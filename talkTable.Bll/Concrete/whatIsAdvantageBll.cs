using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
   public class whatIsAdvantageBll: IwhatIsAdvantageBll
    {
        private IwhatIsAdvantageDal _whatIsAdvantageDal;
        public whatIsAdvantageBll(IwhatIsAdvantageDal whatIsAdvantageDal)
        {
            _whatIsAdvantageDal = whatIsAdvantageDal;
        }
    }
}
