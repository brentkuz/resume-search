using ResumeSearch.Web.Core.Logic.Services;
using ResumeSearch.Web.Core.Utility;
using ResumeSearch.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace ResumeSearch.Web.Controllers
{
    public class ResumeController : ControllerBase
    {
        private IResumeService resumeService;
        
        public ResumeController(IResumeService resumeService, ILogger logger) : base(logger)
        {
            this.resumeService = resumeService;
        }
        
        [HttpGet]
        public ActionResult GetResumes()
        {
            try
            {
                var vm = new ResumeListVM(resumeService.GetAllForUser(User.Identity.Name));                
                return PartialView("~/Views/Resume/ResumeListPartial.cshtml", vm);
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Error, "Get resumes failed", ex);
                var vm = new ResumeListVM();
                vm.Notification.Message = "Unable to retrieve your resumes.";
                vm.Notification.Type = NotificationType.Error;
                return PartialView("~/Views/Resume/ResumeListPartial.cshtml", vm);
            }
        }

        [HttpGet]
        public ActionResult GetUpload(string message = null, bool success = true)
        {
            var vm = new UploadVM();
            if (message != null)
                vm.Notification = new NotificationVM(message, success ? NotificationType.Success : NotificationType.Info);
            return PartialView("~/Views/Resume/Upload.cshtml", vm);
        }
        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                HttpPostedFileBase myFile = Request.Files[0];
                var title = myFile.FileName;
                var desc = Request.Form["Description"];
                bool isUploaded = true;
                string message = "Success";

                if (myFile != null)
                {
                    isUploaded = resumeService.UploadResume(User.Identity.Name, title, desc, myFile);
                }

                return Json(new { isUploaded = isUploaded, message = message }, "text/html");
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Error, "Resume upload failed", ex);
                return Json(new { isUploaded = false, message = "Upload failed." }, "text/html");
            }
        }
        [HttpGet]
        public ActionResult Download(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            resumeService.Dispose();
        }
    }
}