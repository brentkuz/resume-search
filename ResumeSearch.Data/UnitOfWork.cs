using ResumeSearch.Data.Contexts;
using ResumeSearch.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();
        IUserRepository UserRepository { get; }
        IResumeRepository ResumeRepository { get; }
        IValueRepository ValueRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private ResumeSearchContext context;
        private IUserRepository userRepository;
        private IResumeRepository resumeRepository;
        private IValueRepository valueRepository;

        public UnitOfWork()
        {
            context = new ResumeSearchContext();
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }
        public IResumeRepository ResumeRepository
        {
            get
            {
                if (resumeRepository == null)
                    resumeRepository = new ResumeRepository(context);
                return resumeRepository;
            }
        }
        public IValueRepository ValueRepository
        {
            get
            {
                if (valueRepository == null)
                    valueRepository = new ValueRepository(context);
                return valueRepository;
            }
        }



        public bool Save()
        {
            return context.SaveChanges() > 0;
        }

        protected void Dispose(bool disposing)
        {
            if(disposing && ! disposed)
            {
                context.Dispose();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}