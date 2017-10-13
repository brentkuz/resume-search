using ResumeSearch.Web.Core.Data;
using ResumeSearch.Web.Core.Data.Entities;
using ResumeSearch.Web.Core.Data.Repositories;
using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.NLP;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface IResumeService : IDisposable
    {
        List<Resume> GetAllForUser(string username);
        bool UploadResume(string username, string title, string description, HttpPostedFileBase content);
        bool DeleteResume(string username, int id);
    }
    public class ResumeService : IResumeService
    {
        private bool disposed = false;
        private IUnitOfWork uow;
        private IFileFactory fileFactory;
       
        public ResumeService(IUnitOfWork uow, IFileFactory fileFactory)
        {
            this.uow = uow;
            this.fileFactory = fileFactory;
        }

        public List<Resume> GetAllForUser(string username)
        {
            return uow.ResumeRepository.GetAllForUser(username);
        }

        public bool UploadResume(string username, string title, string description, HttpPostedFileBase content)
        {
            byte[] bytes;
            //get bytes
            using (var inStr = content.InputStream)
            {
                var memStr = inStr as System.IO.MemoryStream;
                if (memStr == null)
                {
                    memStr = new System.IO.MemoryStream();
                    inStr.CopyTo(memStr);
                }
                bytes = memStr.ToArray();
                memStr.Dispose();
            }
            //process bytes
            var list = uow.ValueRepository.GetStopwords();
            var stopwords = fileFactory.GetStopwordsFile(DocumentType.Set, list);
            var file = fileFactory.GetResumeFile(DocumentType.Bytes, stopwords, bytes);

            //build entity graph
            List<Keyword> words = new List<Keyword>();
            foreach(var w in file)
            {
                words.Add(new Keyword() { Word = w.ToString() });
            }
            var resume = new Resume(title, description, words, bytes, content.ContentType);
     
            resume.User = uow.UserRepository.GetUserByUsername(username);
            
            uow.ResumeRepository.InsertResume(resume);
            return uow.Save();
        }

        public bool DeleteResume(string username, int id)
        {
            throw new NotImplementedException();
        }

        protected void Dispose(bool disposing)
        {
            if(disposing && !disposed)
            {
                uow.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}