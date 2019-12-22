using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IbannerBll
    {
        List<banner> getAll();
        banner getOne(int id);
        bool add(banner banner);
        bool delete(banner banner);
    }
}
