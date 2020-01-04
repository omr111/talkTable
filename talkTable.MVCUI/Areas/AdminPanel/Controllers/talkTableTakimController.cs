using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talkTable.Bll.Abstract;
using talkTable.Bll.Concrete;
using talkTable.Dal.Concrete;
using talkTable.Entities.Entities;

namespace talkTable.MVCUI.Areas.AdminPanel.Controllers
{
    [Authorize]
    public class talkTableTakimController : Controller
    {
        ItalkTableTeamBll _team = new talkTableTeamBll(new talkTableTeamDal());
        // GET: AdminPanel/talkTableTakim
        public ActionResult Index()
        {
     
            return View(_team.getOne(1));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult guncelle(talkTableTeam talkTableTeam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    talkTableTeam isExist = _team.getOne(talkTableTeam.id);
                    if (isExist != null)
                    {
                        isExist.caption = talkTableTeam.caption;
                        isExist.text = talkTableTeam.text;
                        isExist.teamCaption = talkTableTeam.teamCaption;
                        _team.update(isExist);
                        Session["bannerEklenemedi"] = "Başarıyla Güncellendi";
                        return RedirectToAction("index", new { area = "AdminPanel" });
                    }
                    else
                    {
                        Session["bannerEklenemedi"] = "Güncellenmek İstenilen Veri Bulunamadı";
                        return RedirectToAction("index", new { area = "AdminPanel" });
                    }

                }
                else
                {
                    return View("Index");
                }

            }
            catch (Exception e)
            {

                Session["bannerEklenemedi"] = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}