using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeModels c)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Status = "ValidationError";
            }
                if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("poohbearandfriendz@gmail.com");
                    msg.Subject = "Contact Us";
                    msg.IsBodyHtml = false;
                    SmtpClient client = new SmtpClient();
                    sb.Append("Name: " + c.Name);
                    sb.Append(Environment.NewLine);
                    sb.Append("Phone Number: " + c.Phone);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Message: " + c.Message);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    ViewBag.Status = "SendSuccess";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ViewBag.Status = "SendFailure";
                }
            }
            return View();
        }
    }
}


