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
    [Authorize]
    public class KullanimAlanlariController : Controller
    {
        IusingAreaBll _usingArea = new usingAreaBll(new usingAreaDal());
        IareaInfoBll _areaInfo = new areaInfoBll(new areaInfoDal());
        IusingAreaPictureBll _picture = new usingAreaPictureBll(new usingAreaPictureDal());
        // GET: AdminPanel/KullanimAlanlari
        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult kullanimAlanlari()
        {
            ViewBag.kullanimAlanlari = _areaInfo.getAll();
            return View(_usingArea.getOne(1));
        }
       
        [HttpPost]
        public int kullanimAlanlariAciklamaDuzenle(usingArea usingArea)
        {
            usingArea isExist=_usingArea.getOne(usingArea.id);
            if (isExist!=null)
            {
                isExist.areaCaption = usingArea.areaCaption;
                isExist.areaDescription = usingArea.areaDescription;
                bool update=_usingArea.update(isExist);
                if (update)
                {
                    return 1;
                }else
                    return 0;

            }
            else
                return 0;

         
        }
        
        [HttpPost]
        public int kullanimAlanlariEkle(areaInfo info)
        {
            if (ModelState.IsValid)
            {
                info.usingAreaId = 1;
                    
                _areaInfo.add(info);
                return 1;
            }
            else
            {
                return 0;
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
        public ActionResult kullanimAlaniResimleri()
        {
            return View(_picture.getAll());
        }
        [HttpPost]
        public ActionResult kullanimAlanResimEkle(HttpPostedFileBase file)
        {
            try
            {
                
                    int picWidth = settings.usingAreaPicture.Width;
                            int pichHeight = settings.usingAreaPicture.Height;
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
                    if (Directory.Exists(Server.MapPath("/images/usingAreaPicture")))
                    {
                        pictureDraw.Save(Server.MapPath("/images/usingAreaPicture/" + newName));
                    }

                    usingAreaPicture bnr = new usingAreaPicture();
                    bnr.picturePath = "/images/usingAreaPicture/" + newName;
                    bnr.pictureAlt = file.FileName;
                    bnr.usingAreaId=1;
                    bool result = _picture.addPicture(bnr);
                    Session["bannerEklenemedi"] = "";
                    if (result)
                    {
                        Session["bannerEklenemedi"] = "Resim Başarıyla Eklendi";
                    return RedirectToAction("kullanimAlaniResimleri", "KullanimAlanlari", new { area = "AdminPanel" });
                }
                    else
                    {
                        Session["bannerEklenemedi"] = "Resim Kaydı Sırasında Bir Hata Oluştu!";

                        return RedirectToAction("kullanimAlaniResimleri", "KullanimAlanlari", new { area = "AdminPanel" });
                    }
                

             
            }
            catch (Exception e)
            {
                Session["bannerEklenemedi"] = e.Message;
              return RedirectToAction("kullanimAlaniResimleri", "KullanimAlanlari", new { area = "AdminPanel" });
            }

        }
        [HttpPost]
        public ActionResult kullanimAlanResimSil(int id)
        {
            try
            {
                usingAreaPicture bnr = _picture.getOne(id);
                if (bnr != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bnr.picturePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(bnr.picturePath));

                    }

                    bool resultDeleteBanner = _picture.deletePicture(id);

                    if (resultDeleteBanner)
                    {
                        return Json(new { id = 1, message = "Resim Başarıyla Silindi." });
                    }
                    else
                    {
                        return Json(new { id = 0, message = "Bu Resim Silinemedi, Başka Bir Yerde Kullanılıyor Olabilir !" });
                    }

                }
                else
                {
                    return Json(new { id = 0, message = "Silmek İstediğiniz Resim Bulunamadı!" });
                }


            }
            catch (Exception e)
            {
                return Json(new { id = 0, message = e.Message });
            }
        }
    }
}