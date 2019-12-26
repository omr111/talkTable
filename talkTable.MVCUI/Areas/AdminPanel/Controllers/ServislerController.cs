using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talkTable.Bll.Abstract;
using talkTable.Bll.Concrete;
using talkTable.Dal.Concrete;
using talkTable.Entities.Entities;
using talkTable.MVCUI.App_Classes;

namespace talkTable.MVCUI.Areas.AdminPanel.Controllers
{
    public class ServislerController : Controller
    {
        IvalidityBll _service = new validityBll(new validityDal());
        IvaliditySectionBll sectionBll = new validitySectionBll(new validitySectionDal());
        // GET: AdminPanel/Servisler
        public ActionResult Index()
        {
            return View(_service.getOne(1));
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult servisGuncelle(validity validity, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                validity changeValidity = _service.getOne(validity.id);
                if (changeValidity != null)
                {
                    if (file != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(changeValidity.validityPicturePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(changeValidity.validityPicturePath));
                        }
                        int picWidth = settings.bannerSize.Width;
                        int pichHeight = settings.bannerSize.Height;
                        string newName = "";
                        if (file.FileName.Length > 10)
                        {

                            newName = Path.GetFileNameWithoutExtension(file.FileName.Substring(0, 10)) + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        }
                        else
                        {

                            newName = Path.GetFileNameWithoutExtension(file.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        }
                        Image orjResim = Image.FromStream(file.InputStream);
                        Bitmap pictureDraw = new Bitmap(orjResim, picWidth, pichHeight);
                        if (Directory.Exists(Server.MapPath("/images/serviceBackground")))
                        {
                            pictureDraw.Save(Server.MapPath("/images/serviceBackground/" + newName));
                        }


                        changeValidity.validityPicturePath = "/images/serviceBackground/" + newName;
                        changeValidity.pictureAlt = file.FileName;

                    }
                    changeValidity.caption = validity.caption;
                    changeValidity.infoText = validity.infoText;
                    _service.update(changeValidity);
                    return RedirectToAction("index", new { area = "AdminPanel" });
                }
                else
                    return View("index");
            }
            else
                return View("index", _service.getOne(1));
        }
        public ActionResult servisListesi() { return View(sectionBll.getAll()); }
        public ActionResult altServisEkle()
        {
            validitySection section = new validitySection();
            section.validityId = 1;
            return View(section);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult altServisEkle(validitySection section)
        {
            if (ModelState.IsValid)
            {
                sectionBll.add(section);
                Session["bannerEklenemedi"] = "Servis Başarıyla Eklendi";
                return RedirectToAction("altServisEkle");
            }
            else return View("altServisEkle");
        }
        public ActionResult altServisGuncelle(int id)
        {
            validitySection update = sectionBll.getOne(id);
            if (update != null)
            {
                return View(update);
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult altServisGuncelle(validitySection section)
        {
            if (ModelState.IsValid)
            {
                validitySection changesection =sectionBll.getOne(section.id);
                if(changesection!=null)
                {
                    changesection.infoText = section.infoText;
                    changesection.caption = section.caption;

                    sectionBll.update(changesection);
                    return RedirectToAction("servisListesi");
                }
                return View("altServisGuncelle");

            }
            else return View("altServisGuncelle", section);
        }
        [HttpPost]
        public ActionResult altServisSil(int id)
        {
            try
            {
                validitySection section = sectionBll.getOne(id);
                if (section != null)
                {
                   
                    bool resultDelete = sectionBll.delete(section);

                    if (resultDelete)
                    {
                        return Json(new { id = 1, message = "Section Başarıyla Silindi." });
                    }
                    else
                    {
                        return Json(new { id = 0, message = "Bu Section Silinemedi, Lütfen Tekrar Deneyiniz !" });
                    }

                }
                else
                {
                    return Json(new { id = 0, message = "Silmek İstediğiniz Section Bulunamadı!" });
                }


            }
            catch (Exception e)
            {
                return Json(new { id = 0, message = e.Message });
            }
        }
    }
}