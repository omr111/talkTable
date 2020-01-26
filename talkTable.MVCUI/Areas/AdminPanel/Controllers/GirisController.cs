using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using talkTable.Bll.Abstract;
using talkTable.Bll.Concrete;
using talkTable.Dal.Concrete;
using talkTable.Entities.Entities;
using talkTable.MVCUI.App_Classes;

namespace talkTable.MVCUI.Areas.AdminPanel.Controllers
{
    public class GirisController : Controller
    {
        IsiteInformationBll _site = new siteInformationBll(new siteInformationDal());
        // GET: AdminPanel/Giris
        public ActionResult Index()
        {
          
            return View();
        }
        public ActionResult girisYap()
        {
         
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult girisYap(string emailAddress,string loginPassword)
        {
           
            
                if (ModelState.IsValid)
                {
                    siteInformation isExistSite = _site.getOne(settings.siteInformation);
                    if (isExistSite != null)
                    {
                        if (isExistSite.emailAddress == emailAddress && isExistSite.password == loginPassword)
                        {
                       
                            FormsAuthentication.SetAuthCookie(isExistSite.emailAddress, false);
                        
                            return RedirectToAction("Index", "Home", new { area = "AdminPanel" });
                        }
                        else
                        {
                            ViewData["logInError"] = "Email ya da Şifre Yanlış!";
                            return View("girisYap");
                        }
                    }
                    else
                    {
                        ViewData["logInError"] = "Email ya da Şifre Yanlış!";
                        return View("girisYap");
                    }
                }
                else
                    return View();
            
        }

        public ActionResult cikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("girisYap", "Giris", new { area = "AdminPanel" });
        }
        public ActionResult SifreSifirla() { return View(); }
        [HttpPost]
        public ActionResult SifreSifirla(string changeName)
        {
            try
            {

                siteInformation company = _site.getOne(settings.siteInformation);



                if (company.emailAddress == changeName)
                {
                    Random random = new Random();
                    int sifreUret = random.Next(15689, 99586);

                    company.password = sifreUret.ToString();
                    bool resultUpdate = _site.update(company);

                    if (resultUpdate)
                    {


                        // mail adresi ve şifresi ne ise adminpanelden company information'dan mail ve şifreyi de aynısını yapmalı!
                        var senderEmail = new MailAddress(company.emailAddress.Trim(), "");
                        var receiverEmail = new MailAddress(company.emailAddress.Trim(), "Receiver");

                        var password = company.emailPassword.Trim();
                        var sub = "cloudevi.io Yeni Şifre";
                        var body = string.Format("Yeni Şifreniz {0}", company.password);
                        var HostSplit = company.emailAddress.Split('@')[1].ToString();

                        var smtp = new SmtpClient
                        {
                            Timeout = 10000,
                            Host = "mail." + HostSplit,
                            Port = 587,
                            EnableSsl = false,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = true,
                            Credentials = new NetworkCredential(senderEmail.Address, password),

                        };
                        using (var mess = new MailMessage(senderEmail, receiverEmail)
                        {
                            IsBodyHtml = true,
                            BodyEncoding = System.Text.UTF8Encoding.UTF8,
                            Subject = sub,
                            Body = body,
                            DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,

                        })
                        {
                            smtp.Send(mess);
                        }

                        return Json("Yeni Şifreniz Mail Adresinize Gönderildi.");
                    }
                    else
                    {

                        return Json("Mail Gönderilemedi Lütfen Tekrar Deneyiniz.");
                    }


                }
                else
                {

                    return Json("Girilen Mail Adresi Kullanılmıyor !");
                }

            }



            catch (Exception EX_NAME)
            {
                ViewData["resetInfo"] = "Girilen Mail Adresi Kullanılmıyor !";
                return View("Index");
            }


        }
    }
}