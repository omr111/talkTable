using ImageResizer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        public ActionResult bannerEkle(banner bnr, HttpPostedFileBase file, HttpPostedFileBase flash)
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
                        if (flash != null)
                        {


                            int iconWidth = settings.bannerFlash.Width;
                            int iconHeight = settings.bannerFlash.Height;
                            string iconnewName = "";
                            if (flash.FileName.Length > 10)
                            {

                                iconnewName = Path.GetFileNameWithoutExtension(flash.FileName.Substring(0, 9)) + Guid.NewGuid() + Path.GetExtension(flash.FileName);
                            }
                            else
                            {

                                iconnewName = Path.GetFileNameWithoutExtension(flash.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(flash.FileName);
                            }
                            var combine = Path.Combine(Server.MapPath("/images/bannerPictures/flash"), iconnewName);
                            if (Directory.Exists(Server.MapPath("/images/bannerPictures/flash")))
                            {

                                flash.SaveAs(combine);


                            }



                            bnr.onBannerFlashPath = "/images/bannerPictures/flash/" + iconnewName;


                        }

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
        public ActionResult bannerDuzenle(int? id)
        {
            if (id.HasValue)
            {
                return View(_banner.getOne(id.Value));
            }
            else
                return RedirectToAction("index");
        }
       [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult bannerDuzenle(banner bnr, HttpPostedFileBase file, HttpPostedFileBase flash)
        {
            if (ModelState.IsValid)
            {
                banner changeBanner = _banner.getOne(bnr.id);
                if (changeBanner != null)
                {
                    if (flash != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(changeBanner.onBannerFlashPath)))
                        {
                            System.IO.File.Delete(Server.MapPath(changeBanner.onBannerFlashPath));
                        }
                        int iconWidth = settings.bannerFlash.Width;
                        int iconHeight = settings.bannerFlash.Height;
                        string iconnewName = "";
                        if (flash.FileName.Length > 10)
                        {

                            iconnewName = Path.GetFileNameWithoutExtension(flash.FileName.Substring(0, 9)) + Guid.NewGuid() + Path.GetExtension(flash.FileName);
                        }
                        else
                        {

                            iconnewName = Path.GetFileNameWithoutExtension(flash.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(flash.FileName);
                        }
                       
                     
                        var combine = Path.Combine(Server.MapPath("/images/bannerPictures/flash"), iconnewName);
                        if (Directory.Exists(Server.MapPath("/images/bannerPictures/flash")))
                        {
                           
                            flash.SaveAs(combine);
                           

                        }


                        
                        changeBanner.onBannerFlashPath = "/images/bannerPictures/flash/"+iconnewName;

                    }
                    if (file != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(changeBanner.bannerPath)))
                        {
                            System.IO.File.Delete(Server.MapPath(changeBanner.bannerPath));
                        }
                        changeBanner.bannerPath = resimEkle(file, HttpContext, "/images/bannerPictures");
                    }
                    changeBanner.onBannerText = bnr.onBannerText;
                    changeBanner.onBannerCaption = bnr.onBannerCaption;
                    _banner.update(changeBanner);
                    Session["bannerDuzenle"] = "Banner Başarıyla Düzenlendi";
                    return RedirectToAction("bannerDuzenle", "Banner", new { area = "AdminPanel", id=changeBanner.id });
                }
                return View("bannerDuzenle");
            }
           
            return View("bannerDuzenle");
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
                bool resultDeleteBanner;
                if (bnr != null)
                {
                    if (bnr.bannerBoxInfo.Any())
                    {
                        List<bannerBoxInfo> boxes=_bannerBoxInfo.getAllByBannerId(bnr.id);
                        foreach (var item in boxes)
                        {
                            _bannerBoxInfo.delete(item);
                            if (System.IO.File.Exists(Server.MapPath(item.boxIconPath)))
                            {
                                System.IO.File.Delete(Server.MapPath(item.boxIconPath));

                            }
                         
                        }
                        banner bnr1 = _banner.getOne(id);//ilişkili veriler silindikten sonra veri uyuşmazlığı olduğu için hata veriyor. O yüzden veri yeniledim.
                        resultDeleteBanner= _banner.delete(bnr1);
                        if (System.IO.File.Exists(Server.MapPath(bnr1.bannerPath)))
                        {
                            System.IO.File.Delete(Server.MapPath(bnr1.bannerPath));

                        }
                    }
                    else
                    {
                        resultDeleteBanner = _banner.delete(bnr);
                        if (System.IO.File.Exists(Server.MapPath(bnr.bannerPath)))
                        {
                            System.IO.File.Delete(Server.MapPath(bnr.bannerPath));

                        }
                    }
                    
                   
                   
                   

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

        //flash
      
       
        public static string resimEkle(HttpPostedFileBase file, HttpContextBase Cbase,string url)
        {
 
                    if (file != null)
                    {
                        int iconWidth = settings.bannerFlash.Width;
                        int iconHeight = settings.bannerFlash.Height;
                        string iconnewName = "";
                        if (file.FileName.Length > 10)
                        {

                            iconnewName = Path.GetFileNameWithoutExtension(file.FileName.Substring(0, 9)) + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        }
                        else
                        {

                            iconnewName = Path.GetFileNameWithoutExtension(file.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        }
                        Image orjResimIcon = Image.FromStream(file.InputStream);
                        Bitmap pictureDrawIcon = new Bitmap(orjResimIcon, iconWidth, iconHeight);
                        if (Directory.Exists(Cbase.Server.MapPath(url)))
                        {
                            pictureDrawIcon.Save(Cbase.Server.MapPath(url + "/" + iconnewName));
                    
                        }


                       string flashPath = url + "/" + iconnewName;
                       

                            return flashPath;
                       

                    }
                    else
                    {
                        return "";
                    }
                
           


        }

    }
}












