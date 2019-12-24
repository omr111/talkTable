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
                return View("index");
        }
    }
}