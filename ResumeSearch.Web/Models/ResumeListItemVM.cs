using ResumeSearch.Web.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class ResumeListItemVM : BaseVM
    {
        public ResumeListItemVM()
        {
        }
        public ResumeListItemVM(Resume resume)
        {
            Id = resume.Id;
            Title = resume.Title;
            Description = resume.Description;
            UploadDate = ((DateTime)resume.Created).ToString("MM/dd/yyyy");
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UploadDate { get; set; }
    }
}