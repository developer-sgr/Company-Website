using LS.Email;
using Newtonsoft.Json;
using Seguro.Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Seguro.Company.Web.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contactus
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactusModel model, string empty)
        {
            CaptchaResponse response = ValidateCaptcha(Request["g-recaptcha-response"]);
            if (!response.Success || !ModelState.IsValid)
            {
                ModelState.AddModelError("Captcha", "Please verify that you are not a robot.");
                TempData["Message"] = "Captcha is not valid";
                return View();
            }

            Emailer.From("noreply@seguro-soft.com", "").To("info@seguro-soft.com").CC("tilak@seguro-soft.com").Subject("You received a enquiry from company website").Body(GetEmailBody(model)).Send();

            return RedirectToAction("ThankYou");
        }

        private string GetEmailBody(ContactusModel model)
        {
            StringBuilder sbBody = new StringBuilder();
            sbBody.Append("<table border='1' cellpadding='0' cellspacing='0'>");

            sbBody.Append("<tr>");
            sbBody.Append("<td>Name");
            sbBody.Append("</td>");
            sbBody.Append("<td>" + model.Name);
            sbBody.Append("</td>");
            sbBody.Append("</tr>");

            sbBody.Append("<tr>");
            sbBody.Append("<td>Phone");
            sbBody.Append("</td>");
            sbBody.Append("<td>" + model.Phone);
            sbBody.Append("</td>");
            sbBody.Append("</tr>");

            sbBody.Append("<tr>");
            sbBody.Append("<td>Email");
            sbBody.Append("</td>");
            sbBody.Append("<td>" + model.Email);
            sbBody.Append("</td>");
            sbBody.Append("</tr>");

            sbBody.Append("<tr>");
            sbBody.Append("<td>Subject");
            sbBody.Append("</td>");
            sbBody.Append("<td>" + model.Subject);
            sbBody.Append("</td>");
            sbBody.Append("</tr>");

            sbBody.Append("<tr>");
            sbBody.Append("<td>Details");
            sbBody.Append("</td>");
            sbBody.Append("<td>" + model.Message);
            sbBody.Append("</td>");
            sbBody.Append("</tr>");

            sbBody.Append("</table>");

            return sbBody.ToString();
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secretKey = System.Web.Configuration.WebConfigurationManager.AppSettings["RecaptchaPrivateKey"];
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        }
    }
}