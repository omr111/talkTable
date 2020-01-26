
using System;
using System.Drawing;
using System.IO;
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
    public class NasilCalisirController : Controller
    {
        // GET: AdminPanel/NasilCalisir
        IhowIsWorkBll _how = new howIsWorkBll(new howIsWorkDal());
        IhowIsWorkStepBll _step = new howIsWorkStepBll(new howIsWorkStepDal());
        IhowIsWorkPictureBll _picture = new howIsWorkPictureBll(new howIsWorkPictureDal());
        IhowIsWorkIconBll _icon = new howIsWorkIconBll(new howIsWorkIconDal());
        public ActionResult Index()
        {

            return View(_how.getOne(settings.how));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult guncelle(howIsWork how)
        {
            if (ModelState.IsValid)
            {
                howIsWork isExist = _how.getOne(how.id);
                if (isExist != null)
                {
                    isExist.InfoText = how.InfoText;
                    isExist.captionText = how.captionText;
                    _how.update(isExist);
                    return RedirectToAction("index", "NasilCalisir", new { area = "AdminPanel" });
                }
                else
                    return View();
            }
            else
                return View("index");
        }
        public ActionResult NasilCalisirAdimlari()
        {
            return View(_step.getAll());
        }
        public ActionResult nasilCalisirAdimlariEkle(int id)
        {
            howIsWorkStep steps = new howIsWorkStep();
            steps.howIsWorkId = settings.how;
            return View(steps);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult nasilCalisirAdimlariEkle(howIsWorkStep step)
        {
            if (ModelState.IsValid)
            {
                step.howIsWorkId = settings.how;
                _step.add(step);
                Session["bannerEklenemedi"] = "Adım Başarıyla Eklendi";
                return RedirectToAction("NasilCalisirAdimlari", "NasilCalisir", new { area = "AdminPanel" });

            }
            else
                return View("NasilCalisirAdimlari");
        }
        public ActionResult adimGuncelle(int id)
        {
            howIsWorkStep steps = _step.getOne(id);

            return View(steps);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult adimGuncelle(howIsWorkStep step)
        {
            if (ModelState.IsValid)
            {
                howIsWorkStep isExist = _step.getOne(step.id);
                if (isExist != null)
                {
                    isExist.stepText = step.stepText;

                    _step.update(isExist);
                    Session["bannerEklenemedi"] = "Adım Başarıyla Güncellendi";
                    return RedirectToAction("NasilCalisirAdimlari", "NasilCalisir", new { area = "AdminPanel" });
                }
                else
                {
                    Session["bannerEklenemedi"] = "Aranılan Adım Bulunamadı !";
                    return View();
                }

            }
            else
                return View("NasilCalisirAdimlari", _step.getAll());
        }
        public int adimSil(int id)
        {
            howIsWorkStep step = _step.getOne(id);
            if (step != null)
            {
                _step.delete(step);
               
                return 1;
            }
            return 0;
        }
        public ActionResult nasilCalisirResim()
        {
            return View(_picture.getAll());
        }
        public ActionResult nasilCalisirResimEkle()
        {
            howIsWorkPicture work = new howIsWorkPicture();
            work.howIsWorkId = settings.how;
            return View(work);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult nasilCalisirResimEkle(howIsWorkPicture picture, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {


                if (file != null)
                {
                    int picWidth = settings.howIsWorkPicture.Width;
                    int pichHeight = settings.howIsWorkPicture.Height;
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
                    if (Directory.Exists(Server.MapPath("/images/howIsWorkPicture")))
                    {
                        pictureDraw.Save(Server.MapPath("/images/howIsWorkPicture/" + newName));
                    }


                    picture.picturePath = "/images/howIsWorkPicture/" + newName;
                    picture.pictureAlt = file.FileName;
                   

                    _picture.add(picture);
                    Session["bannerEklenemedi"] = "Resim Başarıyla Eklendi";
                    return RedirectToAction("nasilCalisirResim", new { area = "AdminPanel" });
                }
                else
                    Session["bannerEklenemedi"] = "Lütfen Eklemek İstediğiniz Resmi Ekleyiniz";
                return View("nasilCalisirResimEkle", picture);

            }
            else
                return View("nasilCalisirResimEkle", picture);
        }
        public ActionResult nasilCalisirResimGuncelle(int id)
        {
            return View(_picture.getOne(id));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult nasilCalisirResimGuncelle(howIsWorkPicture pic, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                howIsWorkPicture changePicture = _picture.getOne(pic.id);
                if (changePicture != null)
                {
                    if (file != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(changePicture.picturePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(changePicture.picturePath));
                        }
                        int picWidth = settings.howIsWorkPicture.Width;
                        int pichHeight = settings.howIsWorkPicture.Height;
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
                        if (Directory.Exists(Server.MapPath("/images/howIsWorkPicture")))
                        {
                            pictureDraw.Save(Server.MapPath("/images/howIsWorkPicture/" + newName));
                        }


                        changePicture.picturePath = "/images/howIsWorkPicture/" + newName;
                        changePicture.pictureAlt = file.FileName;
                        changePicture.pictureText = pic.pictureText;
                        changePicture.stepText = pic.stepText;

                        _picture.update(changePicture);
                        Session["bannerEklenemedi"] = "Resim Başarıyla Güncellendi";
                        return RedirectToAction("nasilCalisirResim", new { area = "AdminPanel" });
                    }
                    else
                        Session["bannerEklenemedi"] = "Lütfen Güncellemek İstediğiniz Resmi Ekleyiniz";
                    return View("nasilCalisirResimGuncelle", pic);
                }
                else
                    Session["bannerEklenemedi"] = "Değiştirilmek İstenilen Resim Bulunamadı !";
                return View("nasilCalisirResimGuncelle", pic);
            }
            else
                return View("nasilCalisirResimGuncelle", pic);
        }
        public ActionResult nasilCalisirResimSil(int id)
        {
            howIsWorkPicture isExist = _picture.getOne(id);
            if (isExist != null)
            {
                if (System.IO.File.Exists(Server.MapPath(isExist.picturePath)))
                {
                    System.IO.File.Delete(Server.MapPath(isExist.picturePath));
                }
                _picture.delete(isExist);
                return Json(new { id = 1, message = "Resim Başarıyla Silindi!" });
            }
            else return Json(new { id = 0, message = "Resim Silinemedi, Lütfen Tekrar Deneyiniz!" });

        }



        //icon
        public ActionResult nasilCalisirIcon(int id)
        {
            return View(_icon.getAllByPictureId(id));
        }
        public ActionResult nasilCalisirIconEkle(int id)
        {
            howIsWorkIcon icon = new howIsWorkIcon();
            icon.howIsworkPictureId = id;
            return View(icon);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult nasilCalisirIconEkle(howIsWorkIcon icon, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {


                if (file != null)
                {
                    int picWidth = settings.howIsWorkIcon.Width;
                    int pichHeight = settings.howIsWorkIcon.Height;
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
                    if (Directory.Exists(Server.MapPath("/images/howIsWorkIcon")))
                    {
                        pictureDraw.Save(Server.MapPath("/images/howIsWorkIcon/" + newName));
                    }


                    icon.iconPath = "/images/howIsWorkIcon/" + newName;
                    icon.iconAlt = file.FileName;
                  

                    _icon.add(icon);
                   
                    return RedirectToAction("nasilCalisirIcon", new { area = "AdminPanel",id=icon.howIsworkPictureId });
                }
                else
                    Session["bannerEklenemedi"] = "Lütfen Eklemek İstediğiniz İkonu Ekleyiniz";
                return View("nasilCalisirIconEkle", icon);

            }
            else
                return View("nasilCalisirIconEkle", icon);
        }
        public ActionResult nasilCalisirIconGuncelle(int? id)
        {
            if (id.HasValue)
            {
                return View(_icon.getOne(id.Value));
            } else
                return RedirectToAction("nasilCalisirIcon", "NasilCalisir", new { area = "AdminPanel" }); 


        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult nasilCalisirIconGuncelle(howIsWorkIcon icon, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                howIsWorkIcon changeicon = _icon.getOne(icon.id);
                if (changeicon != null)
                {
                    if (file != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(changeicon.iconPath)))
                        {
                            System.IO.File.Delete(Server.MapPath(changeicon.iconPath));
                        }
                        int picWidth = settings.howIsWorkIcon.Width;
                        int pichHeight = settings.howIsWorkIcon.Height;
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
                        if (Directory.Exists(Server.MapPath("/images/howIsWorkIcon")))
                        {
                            pictureDraw.Save(Server.MapPath("/images/howIsWorkIcon/" + newName));
                        }


                        changeicon.iconPath = "/images/howIsWorkIcon/" + newName;
                        changeicon.iconAlt = file.FileName;
                        changeicon.iconText = icon.iconText;

                        _icon.update(changeicon);
                     
                        return RedirectToAction("nasilCalisirIcon", new { area = "AdminPanel",id=changeicon.howIsworkPictureId });
                    }
                    else
                        Session["bannerEklenemedi"] = "Lütfen Güncellemek İstediğiniz İkonu Ekleyiniz";
                    return View("nasilCalisirIconGuncelle", icon);
                }
                else
                    Session["bannerEklenemedi"] = "Değiştirilmek İstenilen İkon Bulunamadı !";
                return View("nasilCalisirIconGuncelle", icon);
            }
            else
                return View("nasilCalisirIconGuncelle", icon);
        }
        public int nasilCalisirIconSil(int id)
        {
            howIsWorkIcon isExist = _icon.getOne(id);
            if (isExist != null)
            {
                if (System.IO.File.Exists(Server.MapPath(isExist.iconPath)))
                {
                    System.IO.File.Delete(Server.MapPath(isExist.iconPath));
                }
                _icon.delete(isExist);
                return 1;
            }
            else return 0;

        }


    }
}