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
        List<Resume> GetByIdList(List<int> ids);
        void InsertResume(Resume resume);
        void DeleteResume(Resume resume);
    }
    public class ResumeRepository : RepositoryBase, IResumeRepository
    {
        public ResumeRepository(ResumeSearchContext context) : base(context)
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

        public List<Resume> GetByIdList(List<int> ids)
        {
            return context.Resumes.Where(r => ids.Contains(r.Id)).ToList();
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