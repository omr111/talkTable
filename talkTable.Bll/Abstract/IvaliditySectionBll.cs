using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IvaliditySectionBll
    {
        List<validitySection> getAll();
        validitySection getOne(int id);
        bool add(validitySection validitySection);
        bool delete(validitySection validitySection);
        bool update(validitySection validitySection);
    }
}
