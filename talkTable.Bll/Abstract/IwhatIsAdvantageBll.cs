using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
   public interface IwhatIsAdvantageBll
    {
        whatIsAdvantage getOne(int id);
        bool add(whatIsAdvantage whatIsAdvantage);
        bool update(whatIsAdvantage whatIsAdvantage);
        bool delete(whatIsAdvantage whatIsAdvantage);
    }
}
