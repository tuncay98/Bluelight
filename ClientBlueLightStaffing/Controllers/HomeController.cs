using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ClientBlueLightStaffing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        string sMsg;

        public ActionResult Send(string name, string phone, string email, string message) {

            string smtpAddress = "relay-hosting.secureserver.net";
            int portNumber = 25;
            bool enableSSL = false;

            string emailFrom = "tuncayhuseynov@gmail.com";
            string password = "5591980supertun";
            string emailTo = "rachel@bluelightstaffing.com";
            

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = "Support Desk Message";


                sMsg = "Name : " + name + "\nEmail : " + email + "\nPhone : " + phone + "\nMessage : " + message;





                mail.Body = sMsg;
                mail.IsBodyHtml = false;
                // Can set to false, if you are sending pure text.



                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

            return RedirectToAction("Index", "Home");
        }


    }
}