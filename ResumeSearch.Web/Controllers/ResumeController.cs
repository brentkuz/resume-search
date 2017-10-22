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
        public ActionResult GetUpload()
        {
            var vm = new UploadVM();
            return PartialView("~/Views/Resume/UploadPartial.cshtml", vm);
        }
        [HttpPost]
        public ActionResult Upload(UploadVM upload)
        {
            try
            {
                if(ModelState.IsValid)
                {                
                    bool isUploaded = false;

                    if (upload.Content != null)
                    {
                        isUploaded = resumeService.UploadResume(User.Identity.Name, upload.Content.FileName, upload.Description, upload.Content);
                    }

                    var vm = new UploadVM()
                    {
                        Notification = new NotificationVM()
                        {
                            Message = isUploaded ? "Success" : "Resume upload failed",
                            Type = isUploaded ? NotificationType.Success : NotificationType.Error
                        }
                    };

                    return PartialView("~/Views/Resume/UploadPartial.cshtml", vm);
                }
                else
                {
                    return PartialView("~/Views/Resume/UploadPartial.cshtml", upload);
                }
                
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Error, "Resume upload failed", ex);
                var vm = new UploadVM()
                {
                    Notification = new NotificationVM()
                    {
                        Message = "Upload could not be completed.",
                        Type = NotificationType.Error
                    }
                };
                return PartialView("~/Views/Resume/UploadPartial.cshtml", vm);
            }
        }
        [HttpGet]
        public ActionResult Download(int id)
        {
            try
            {
                var res = resumeService.GetResume(User.Identity.Name, id);
                return File(res.Content, "application/octet-stream", res.Title);
            }
            catch (Exception ex)
            {
                logger.Log(LogType.Error, "Resume download failed.", ex);
                return RedirectToAction("Error", "Utility", new { message = "An error occurred retrieving your resume." });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var notif = new NotificationVM();
            try
            {
                var res = resumeService.DeleteResume(User.Identity.Name, id);
                notif.Message = "Success";
                notif.Type = NotificationType.Success;
            }
            catch(Exception ex)
            {
                logger.Log(LogType.Error, "Resume delete failed.", ex);
                notif.Message = "Failed to delete";
                notif.Type = NotificationType.Error;
            }

            var vm = new ResumeListVM(resumeService.GetAllForUser(User.Identity.Name));
            vm.Notification = notif;
            return PartialView("~/Views/Resume/ResumeListPartial.cshtml", vm);
            
        }

 
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            resumeService.Dispose();
        }
    }
}