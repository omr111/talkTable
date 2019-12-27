
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
    public class NasilCalisirController : Controller
    {
        // GET: AdminPanel/NasilCalisir
        IhowIsWorkBll _how = new howIsWorkBll(new howIsWorkDal());
        IhowIsWorkStepBll _step = new howIsWorkStepBll(new howIsWorkStepDal());
        IhowIsWorkPictureBll _picture = new howIsWorkPictureBll(new howIsWorkPictureDal());
        public ActionResult Index()
        {

            return View(_how.getOne(1));
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
            steps.howIsWorkId = 1;
            return View(steps);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult nasilCalisirAdimlariEkle(howIsWorkStep step)
        {
            if (ModelState.IsValid)
            {

                _step.add(step);
                Session["bannerEklenemedi"] = "Adım Başarıyla Eklendi";
                return RedirectToAction("index", "NasilCalisirAdimlari", new { area = "AdminPanel" });

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
                    return RedirectToAction("index", "NasilCalisirAdimlari", new { area = "AdminPanel" });
                }
                else
                {
                    Session["bannerEklenemedi"] = "Aranılan Adım Bulunamadı !";
                    return View();
                }

            }
            else
                return View("NasilCalisirAdimlari");
        }
        public ActionResult adimSil(int id)
        {
            howIsWorkStep step = _step.getOne(id);
            if (step != null)
            {
                _step.delete(step);
                Session["bannerEklenemedi"] = "Adım Başarıyla Silindi";
                return RedirectToAction("NasilCalisirAdimlari", "NasilCalisir", new { area = "AdminPanel" });
            }
            return View();
        }
        public ActionResult nasilCalisirResim()
        {
            return View(_picture.getAll());
        }
        public ActionResult nasilCalisirResimEkle()
        {
            howIsWorkPicture work = new howIsWorkPicture();
            work.howIsWorkId = 1;
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
                    picture.pictureText = picture.pictureText;

                    _picture.update(picture);
                    Session["bannerEklenemedi"] = "Resim Başarıyla Güncellendi";
                    return RedirectToAction("nasilCalisirResim", new { area = "AdminPanel" });
                }
                else
                    Session["bannerEklenemedi"] = "Lütfen Güncellemek İstediğiniz Resmi Ekleyiniz";
                return View("nasilCalisirResimGuncelle", picture);

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
                return View("index");
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
                return RedirectToAction("nasilCalisirResim", "nasilCalisir", new { area = "AdminPanel" });
            }
            else return View();
            
        }
    }
}