using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    public class siteBilgileriController : Controller
    {
        IsiteInformationBll _site = new siteInformationBll(new siteInformationDal());
        // GET: AdminPanel/siteBilgileri
        public ActionResult Index()
        {
            siteInformation site = _site.getOne(1);
            return View(site);
        }
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(siteInformation comInfo, HttpPostedFileBase file )
        {
            siteInformation company = _site.getOne(1);


            try
            {
                if (ModelState.IsValid)
                {
                   

                    if (file != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath(company.logoPath)))
                        {

                            System.IO.File.Delete(Server.MapPath(company.logoPath));

                        }

                        int fileWidth = settings.bigLogo.Width;
                        int fileHeight = settings.bigLogo.Height;
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
                        fileDraw.Save(Server.MapPath("~/images/logo/" + newName));

                        company.logoPath = "/images/logo/" + newName;
                     
                    }
                    company.instagramUrl = comInfo.instagramUrl;
                    company.twitterUrl = comInfo.twitterUrl;
                    company.faceUrl = comInfo.faceUrl;
                    company.phone = comInfo.phone;
                    company.sendMailCaption = comInfo.sendMailCaption;
                    company.sendMailSubText = comInfo.sendMailSubText;
                    company.siteName = comInfo.siteName;                 
                    company.whatIsThisSiteText1 = comInfo.whatIsThisSiteText1;
                    company.whatIsThisSiteText2 = comInfo.whatIsThisSiteText2;
                     company.emailPassword = comInfo.emailPassword;
                    company.emailAddress = comInfo.emailAddress;                   
                    company.address = comInfo.address;
                 
                    bool result = _site.update(company);
                    //todo uyarı mesajları yapılacak.
                    if (result)
                    {
                        return RedirectToAction("Index", "siteBilgileri", new { area = "AdminPanel" });
                    }
                    return RedirectToAction("Index", "siteBilgileri", new { area = "AdminPanel" });
                }
                else
                {
                    return View("Index", company);
                }


            }
           
            catch (DbEntityValidationException e)
            {
                
                foreach(var item in e.EntityValidationErrors.ToList())
                {
                    foreach(var error in item.ValidationErrors.ToList())
                    {
                        ModelState.AddModelError("", error.ErrorMessage);
                    }
                    
                }
             
                return View("Index",company);
            }


        }

    }
}