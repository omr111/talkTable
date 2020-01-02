using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using talkTable.Bll.Abstract;
using talkTable.Bll.Concrete;
using talkTable.Dal.Concrete;
using talkTable.Entities.Entities;

namespace talkTable.MVCUI.Controllers
{
    public class mailController : Controller
    {
        IsendMailBll _sendMail = new sendMailBll(new sendMailDal());
        IsiteInformationBll site = new siteInformationBll(new siteInformationDal());
        // GET: mail
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public int sendMail(sendMail review)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    siteInformation company = site.getOne(1);

                    // mail adresi ve şifresi ne ise adminpanelden company information'dan mail ve şifreyi de aynısını yapmalı!
                    var senderEmail = new MailAddress(review.mailAddress.Trim(), "");
                    var receivereEmail = new MailAddress(company.emailAddress.Trim(), "Receiver");
                    var password = company.emailPassword.Trim();

                    var sub = review.nameSurname+" | "+review.companyName;
                    var body = review.mailText;
                    var smtp = new SmtpClient

                    {
                        Timeout = 10000,
                        Host = "mail.talktable.net",
                        Port = 587,
                        EnableSsl = false,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receivereEmail)
                    {
                        IsBodyHtml = true,
                        BodyEncoding = Encoding.UTF8,
                        Subject = sub.ToString(),
                        Body = body.ToString(),
                        DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,

                    })
                    {
                        smtp.Send(mess);
                    }
                    return 1;


                }
                return 0;
                    
            }
            catch (Exception e)
            {
                return 0;
                
            }

        }
    }
}