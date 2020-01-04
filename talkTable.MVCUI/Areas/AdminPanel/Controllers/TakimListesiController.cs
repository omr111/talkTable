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
    public class TakimListesiController : Controller
    {
        IteamMemberBll _member = new teamMemberBll(new teamMemberDal());
        // GET: AdminPanel/TakimListesi
        public ActionResult Index()
        {
            return View(_member.getAll());
        }
        public ActionResult UyeEkle()
        {
            teamMember teamMember = new teamMember();
            teamMember.talkTableTeamId = 1;
            return View(teamMember);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UyeEkle(teamMember teamMember,HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {

                        int picWidth = settings.userPhoto.Width;
                        int pichHeight = settings.userPhoto.Height;
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
                        if (Directory.Exists(Server.MapPath("/images/memberPhoto")))
                        {
                            pictureDraw.Save(Server.MapPath("/images/memberPhoto/" + newName));
                        }


                        teamMember.picturePath = "/images/memberPhoto/" + newName;
                        teamMember.pictureAlt = file.FileName;

                        bool result = _member.add(teamMember);
                        Session["bannerEklenemedi"] = "";
                        if (result)
                        {

                            Session["bannerEklenemedi"] = "Üye Başarıyla Eklendi";

                            return RedirectToAction("index", "TakimListesi", new { area = "AdminPanel" });
                        }
                        else
                        {
                            Session["bannerEklenemedi"] = "Üye Kaydı Sırasında Bir Hata Oluştu!";

                            return RedirectToAction("index", "TakimListesi", new { area = "AdminPanel" });
                        }

                    }
                    else
                    {
                        //Session["bannerEklenemedi"] = "Resim Alanı Boş Geçilemez!";
                        ModelState.AddModelError("", "Üye resmini yüklemek zorundasınız.");
                      
                        return View(teamMember);
                    }
                }
                else
                {
                 
                    return View(teamMember);
                }



            }
            catch (Exception e)
            {
                Session["bannerEklenemedi"] = e.Message;
                return RedirectToAction("index", "TakimListesi", new { area = "AdminPanel" });
            }
        }
        public ActionResult UyeGuncelle(int id)
        {
            teamMember member= _member.getOne(id);
            if (member != null)
            {
                return View(member);
            }
            else
                return null;
            
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UyeGuncelle(teamMember teamMember,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                teamMember changeMember = _member.getOne(teamMember.id);
                if (changeMember != null)
                {
                    if (file != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(changeMember.picturePath)))
                        {
                            System.IO.File.Delete(Server.MapPath(changeMember.picturePath));
                        }
                        int picWidth = settings.userPhoto.Width;
                        int pichHeight = settings.userPhoto.Height;
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
                        if (Directory.Exists(Server.MapPath("/images/memberPhoto")))
                        {
                            pictureDraw.Save(Server.MapPath("/images/memberPhoto/" + newName));
                        }


                        changeMember.picturePath = "/images/memberPhoto/" + newName;
                        changeMember.pictureAlt = file.FileName;

                    }
                    changeMember.job = teamMember.job;
                    changeMember.name = teamMember.name;
                    _member.update(changeMember);
                    return RedirectToAction("index", new { area = "AdminPanel" });
                }
                else
                    return View();
            }else
                return View();
        }
        [HttpPost]
        public ActionResult UyeSil(int id )
        {

            try
            {
                teamMember bnr = _member.getOne(id);
                if (bnr != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bnr.picturePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(bnr.picturePath));

                    }
            

                    bool resultDeleteBanner = _member.delete(bnr);

                    if (resultDeleteBanner)
                    {
                        return Json(new { id = 1, message = "Üye Başarıyla Silindi." });
                    }
                    else
                    {
                        return Json(new { id = 0, message = "Bu Üye Silinemedi, Tekrar Deneyiniz!" });
                    }

                }
                else
                {
                    return Json(new { id = 0, message = "Silmek İstediğiniz Üye Bulunamadı!" });
                }


            }
            catch (Exception e)
            {
                return Json(new { id = 0, message = e.Message });
            }
          
        }
    }
}