using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talkTable.Bll.Abstract;
using talkTable.Bll.Concrete;
using talkTable.Dal.Concrete;
using talkTable.Entities.Entities;
using talkTable.MVCUI.Models;

namespace talkTable.MVCUI.Controllers
{
    public class AnaSayfaController : Controller
    {
        IhowIsWorkBll _how = new howIsWorkBll(new howIsWorkDal());
        IusingAreaBll _usingArea = new usingAreaBll(new usingAreaDal());
        IvalidityBll _service = new validityBll(new validityDal());
        IsiteInformationBll _site = new siteInformationBll(new siteInformationDal());
        ItalkTableTeamBll _member = new talkTableTeamBll(new talkTableTeamDal());
        IwhatIsAdvantageBll advantageBll = new whatIsAdvantageBll(new whatIsAdvantageDal());
        IbannerBll _banner = new bannerBll(new bannerDal());
        // GET: AnaSayfa
        public ActionResult Index()
        {
            homeModels home = new homeModels();
            howIsWorkModel how = new howIsWorkModel();
            bannerModels bannerModel = new bannerModels();
            siteInformation site = _site.getOne(1);
            List<banner> banner = _banner.getAll();
            usingArea area = _usingArea.getOne(1);
            whatIsAdvantage advantage = advantageBll.getOne(1);
            validity service = _service.getOne(1);
            talkTableTeam member = _member.getOne(1);
            bannerModel.banners = banner;
            bannerModel.site = site;

            how.site = site;
            how.HowIsWork = _how.getOne(1);

            home.how = _how.getOne(1);
            home.banner = bannerModel;
            home.site = site;
            home.area = area;
            home.advantage = advantage;
            home.service = service;
            home.team = member;
            return View(home);
        }
    }
}