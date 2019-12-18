using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Bll.Abstract;
using talkTable.Dal.Abstract;

namespace talkTable.Bll.Concrete
{
    public class advantageBll: IadvantageBll
    {
      private  IadvantageDal _advangeDal;
        public advantageBll(IadvantageDal advangeDal)
        {
            _advangeDal = advangeDal;
        }
    }
}
