using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResumeSearch.Web.Core.Data.Contexts;
using ResumeSearch.Web.Core.Data.Entities;

namespace ResumeSearch.Web.Core.Data.Repositories
{
    public interface IResumeRepository
    {
        List<Resume> GetAllForUser(string username);
        Resume GetById(int id);
        void InsertResume(Resume resume);
        void DeleteResume(Resume resume);
    }
    public class ResumeRepository : RepositoryBase, IResumeRepository
    {
        public ResumeRepository(AppContext context) : base(context)
        {
        }

        public List<Resume> GetAllForUser(string username)
        {
            return context.Resumes.Where(r => r.User.Username == username)
                .OrderByDescending(o => o.Created).ToList();
        }

        public Resume GetById(int id)
        {
            return context.Resumes.Find(id);
        }

        public void InsertResume(Resume resume)
        {
            base.Insert(resume);
            context.Resumes.Add(resume);
        }

        public void DeleteResume(Resume resume)
        {
            context.Resumes.Remove(resume);
        }
    }
}