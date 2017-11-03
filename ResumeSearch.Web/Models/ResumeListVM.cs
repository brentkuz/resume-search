using ResumeSearch.Crosscutting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Models
{
    public class ResumeListVM : BaseVM
    {
        public ResumeListVM()
        {
            Resumes = new List<ResumeListItemVM>();
        }
        public ResumeListVM(IEnumerable<Resume> items)
        {
            Resumes = new List<ResumeListItemVM>();
            foreach (var i in items)
                Resumes.Add(new ResumeListItemVM(i));
        }
        public List<ResumeListItemVM> Resumes { get; set; }
    }
}