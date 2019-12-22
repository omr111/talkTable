using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using talkTable.Entities.Entities;

namespace talkTable.Bll.Abstract
{
    public interface IbannerBoxInfoBll
    {
        List<bannerBoxInfo> getAll();
        List<bannerBoxInfo> getAllByBannerId(int id);
        bannerBoxInfo getOne(int id);
        bannerBoxInfo getOneByBannerId(int id);
        bool add(bannerBoxInfo bannerBoxInfo);
        bool delete(bannerBoxInfo bannerBoxInfo);
        bool update(bannerBoxInfo bannerBoxInfo);
    }
}
