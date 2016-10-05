using MVCProject.Managers;
using MVCProject.Models;
using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class SignUpController : Controller
    {
        static ViewModel vmAccount = new ViewModel();

        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCredentialInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCredentialInfo(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View("GetBasicInfo",model);
            }
            else
            {
                return View("GetCredentialInfo", model);
            }
        }

        [HttpGet]
        public ActionResult GetBasicInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBasicInfo(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                if (file.ContentLength != 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    model.allBasicInfo.PictureName = fileName;
                }
                else {
                    model.allBasicInfo.PictureName = "default.png";
                }
                return View("GetContactInfo", model);
            }
            else
            {
                return View("GetBasicInfo", model);
            }
        }

        [HttpGet]
        public ActionResult GetContactInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetContactInfo(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View("DisplayAccountInfo",model);
            }
            else
            {
                return View("GetContactInfo", model);
            }
        }

        public ActionResult DisplayAccountInfo()
        {
            return View(vmAccount);
        }

        public JsonResult CheckValidateEmail(string Email, string Username)
        {
            var manager = new SignUpManager();

            var existingEmail = manager.ValidateEmail(Email);
            var existingUsername = manager.ValidateUsername(Username);
            return Json(new { ErrorEmail = existingEmail, ErrorUsername = existingUsername }, JsonRequestBehavior.AllowGet);
        }


    }
}