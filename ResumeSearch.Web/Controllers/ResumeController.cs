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

        public ResumeController() : this(new ResumeService())
        {

        }
        public ResumeController(IResumeService resumeService)
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
                logger.Log(LogType.Error, "Get Resumes Failed", ex);
                var vm = new ResumeListVM();
                vm.Notification.Message = "Unable to retrieve your resumes.";
                vm.Notification.Type = NotificationType.Error;
                return PartialView("~/Views/Resume/ResumeListPartial.cshtml", vm);
            }
        }

        [HttpGet]
        public ActionResult GetUpload()
        {
            var vm = new UploadVM();
            return PartialView("~/Views/Resume/Upload.cshtml", vm);
        }
        [HttpPost]
        public ActionResult Upload()
        {
            HttpPostedFileBase myFile = Request.Files[0];
            var title = myFile.FileName;
            var desc = Request.Form["Description"];
            bool isUploaded = true;
            string message = "File upload success";
           
            if (myFile != null)
            {
                resumeService.UploadResume(User.Identity.Name, title, desc, myFile);
            }
            return Json(new { isUploaded = isUploaded, message = message }, "text/html");
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
    }
}