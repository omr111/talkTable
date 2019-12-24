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
    public class AvantajlarController : Controller
    {
        IwhatIsAdvantageBll advantageBll = new whatIsAdvantageBll(new whatIsAdvantageDal());
        // GET: AdminPanel/Avantajlar
        public ActionResult Index()
        {

            return View(advantageBll.getOne(1));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AvantajGuncelle(whatIsAdvantage whatIsAdvantage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    whatIsAdvantage isExist = advantageBll.getOne(whatIsAdvantage.id);
                    if (isExist != null)
                    {
                        isExist.advantageInfoText = whatIsAdvantage.advantageInfoText;
                        isExist.advantageCaption = whatIsAdvantage.advantageCaption;
                        advantageBll.update(isExist);
                        Session["bannerEklenemedi"] = "Başarıyla Güncellendi";
                        return RedirectToAction("index");
                    }
                    else
                    {
                        Session["bannerEklenemedi"] = "Güncellenmek İstenilen Veri Bulunamadı";
                        return RedirectToAction("index");
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