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
    public class BannerController : Controller
    {
        IbannerBll _banner = new bannerBll(new bannerDal());
        IbannerBoxInfoBll _bannerBoxInfo = new bannerBoxInfoBll(new bannerBoxInfoDal());
        // GET: AdminPanel/Banner
        public ActionResult Index()
        {
            return View(_banner.getAll());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult bannerEkle(banner bnr, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {

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
                        if (Directory.Exists(Server.MapPath("/images/bannerPictures")))
                        {
                            pictureDraw.Save(Server.MapPath("/images/bannerPictures/" + newName));
                        }


                        bnr.bannerPath = "/images/bannerPictures/" + newName;
                        bnr.bannerAlt = file.FileName;

                        bool result = _banner.add(bnr);
                        Session["bannerEklenemedi"] = "";
                        if (result)
                        {

                            Session["bannerEklenemedi"] = "Resim Başarıyla Eklendi";

                            return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
                        }
                        else
                        {
                            Session["bannerEklenemedi"] = "Resim Kaydı Sırasında Bir Hata Oluştu!";

                            return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
                        }

                    }
                    else
                    {
                        //Session["bannerEklenemedi"] = "Resim Alanı Boş Geçilemez!";
                        ModelState.AddModelError("", "Banner resmini yüklemek zorundasınız.");
                        return View("Index");
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
                return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
            }

        }
        public ActionResult bannerIconEkle(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }else
           
            return View(id);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult bannerIconEkle(bannerBoxInfo box, HttpPostedFileBase bannerIcon)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (bannerIcon != null)
                    {
                        int iconWidth = settings.logoIcon.Width;
                        int iconHeight = settings.logoIcon.Height;
                        string iconnewName = "";
                        if (bannerIcon.FileName.Length > 10)
                        {

                            iconnewName = Path.GetFileNameWithoutExtension(bannerIcon.FileName.Substring(0, 10)) + Guid.NewGuid() + Path.GetExtension(bannerIcon.FileName);
                        }
                        else
                        {

                            iconnewName = Path.GetFileNameWithoutExtension(bannerIcon.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(bannerIcon.FileName);
                        }
                        Image orjResimIcon = Image.FromStream(bannerIcon.InputStream);
                        Bitmap pictureDrawIcon = new Bitmap(orjResimIcon, iconWidth, iconHeight);
                        if (Directory.Exists(Server.MapPath("/images/bannerPictures/icons")))
                        {
                            pictureDrawIcon.Save(Server.MapPath("/images/bannerPictures/icons/" + iconnewName));
                        }


                        box.boxIconPath = "/images/bannerPictures/icons/" + iconnewName;
                        box.IconAlt = bannerIcon.FileName;
                        bool result = _bannerBoxInfo.add(box);
                        Session["bannerEklenemedi"] = "";
                        if (result)
                        {

                            Session["bannerEklenemedi"] = "Resim Başarıyla Eklendi";

                            return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
                        }
                        else
                        {
                            Session["bannerEklenemedi"] = "Resim Kaydı Sırasında Bir Hata Oluştu!";

                            return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
                        }

                    }
                    else
                    {
                        Session["bannerEklenemedi"] = "Resim Alanı Boş Geçilemez!";
                        ModelState.AddModelError("", "Banner resmini yüklemek zorundasınız.");
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                Session["bannerEklenemedi"] = e.Message;
                return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
            }


        }
        [HttpPost]
        public ActionResult bannerSil(int id)
        {
            try
            {
                banner bnr = _banner.getOne(id);
                if (bnr != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bnr.bannerPath)))
                    {
                        System.IO.File.Delete(Server.MapPath(bnr.bannerPath));

                    }
                    if (bnr.bannerBoxInfo.Any())
                    {
                        foreach (var item in bnr.bannerBoxInfo)
                        {
                            if (System.IO.File.Exists(Server.MapPath(item.boxIconPath)))
                            {
                                System.IO.File.Delete(Server.MapPath(item.boxIconPath));

                            }
                            _bannerBoxInfo.delete(item);
                        }
                       
                    }
                   
                    bool resultDeleteBanner = _banner.delete(bnr);

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
        public ActionResult boxGetir(int id)
        {
            List<bannerBoxInfo> isExist= _bannerBoxInfo.getAllByBannerId(id);
            if (isExist.Count>0)
            {
                return View(isExist);
            }
            else
                return null;
        }
        

        public int boxSil(int id)
        {
            bannerBoxInfo isExist = _bannerBoxInfo.getOne(id);
            if (System.IO.File.Exists(Server.MapPath(isExist.boxIconPath)))
            {
                System.IO.File.Delete(Server.MapPath(isExist.boxIconPath));

            }
            if (isExist != null) { _bannerBoxInfo.delete(isExist); return 1; }else return 0; 
        }
    }
}












//[HttpPost]
//public ActionResult boxGuncelle(bannerBoxInfo box, HttpPostedFileBase bannerIcon)
//{
//    try
//    {
//        if (ModelState.IsValid)
//        {
//            bannerBoxInfo boxChange = _bannerBoxInfo.getOne(box.id);
//            if (bannerIcon != null)
//            {
//                if (System.IO.File.Exists(Server.MapPath(box.boxIconPath)))
//                {
//                    System.IO.File.Delete(Server.MapPath(box.boxIconPath));

//                }

//                int iconWidth = settings.logoIcon.Width;
//                int iconHeight = settings.logoIcon.Height;
//                string iconnewName = "";
//                if (bannerIcon.FileName.Length > 10)
//                {

//                    iconnewName = Path.GetFileNameWithoutExtension(bannerIcon.FileName.Substring(0, 10)) + Guid.NewGuid() + Path.GetExtension(bannerIcon.FileName);
//                }
//                else
//                {

//                    iconnewName = Path.GetFileNameWithoutExtension(bannerIcon.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(bannerIcon.FileName);
//                }
//                Image orjResimIcon = Image.FromStream(bannerIcon.InputStream);
//                Bitmap pictureDrawIcon = new Bitmap(orjResimIcon, iconWidth, iconHeight);
//                if (Directory.Exists(Server.MapPath("/images/bannerPictures/icons")))
//                {
//                    pictureDrawIcon.Save(Server.MapPath("/images/bannerPictures/icons/" + iconnewName));
//                }


//                boxChange.boxIconPath = "/images/bannerPictures/icons/" + iconnewName;
//                boxChange.boxIconPath = bannerIcon.FileName;

//            }
//            boxChange.boxInText = box.boxInText;
//            boxChange.boxOnButtonValue = box.boxOnButtonValue;
//            bool update = _bannerBoxInfo.update(boxChange);
//            if (update)
//            {
//                Session["bannerEklenemedi"] = "Başarıyla Güncellendi";
//                return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
//            }
//            else
//            {
//                Session["bannerEklenemedi"] = "Güncellenme Sırasında Bir Hata Meydana Geldi";
//                return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
//            }
//        }
//        else
//        {
//            return View();
//        }
//    }
//    catch (Exception e)
//    {

//        Session["bannerEklenemedi"] = e.Message;
//        return RedirectToAction("index", "Banner", new { area = "AdminPanel" });
//    }
//}