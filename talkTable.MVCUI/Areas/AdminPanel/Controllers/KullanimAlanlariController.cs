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
    public class KullanimAlanlariController : Controller
    {
        IusingAreaBll _usingArea = new usingAreaBll(new usingAreaDal());
        IareaInfoBll _areaInfo = new areaInfoBll(new areaInfoDal());
        // GET: AdminPanel/KullanimAlanlari
        public ActionResult Index()
        {
            return View(_usingArea.getOne(1));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult kullanimAlanlariResimEkle(int usingAreaId ,HttpPostedFileBase file)
        {
            try
            {
                usingAreaPicture picture = new usingAreaPicture();
                IusingAreaPictureBll pictureBll = new usingAreaPictureBll(new usingAreaPictureDal());
                int fileWidth = settings.usingAreaPicture.Width;
                int fileHeight = settings.usingAreaPicture.Height;
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
                Bitmap fileDraw = new Bitmap(orjResim, fileWidth, fileHeight);
                fileDraw.Save(Server.MapPath("~/images/usingAreaPicture/" + newName));

                picture.picturePath = "/images/usingAreaPicture/" + newName;
                picture.pictureAlt = newName;
                picture.usingAreaId = usingAreaId;
                pictureBll.addPicture(picture);
                return RedirectToAction("Index", "KullanimAlanlari", new { area = "AdminPanel" });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "KullanimAlanlari", new { area = "AdminPanel" });
            }
         
        }

        public ActionResult kullanimAlanlari()
        {
            return View(_areaInfo.getAll());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult kullanimAlanlariEkle(areaInfo info)
        {
            if (ModelState.IsValid)
            {
                _areaInfo.add(info);
                return RedirectToAction("kullanimAlanlari", "KullanimAlanlari", new { area = "AdminPanel" });
            }
            else
            {
                return RedirectToAction("kullanimAlanlari", "KullanimAlanlari", new { area = "AdminPanel" });
            }
            
        }
       
        [HttpPost]
        public int kullanimAlanlariSil(int id)
        {
            
                areaInfo isExist= _areaInfo.getOne(id);
            if (isExist != null)
            {
                bool resultDelete = _areaInfo.delete(isExist);
                if (resultDelete)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            
            else
            {
                return 0;
            }






             

        }
    }
}