using ResumeSearch.Web.Core.Data.Entities;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.BusinessObjects.Files
{
    public interface IFileFactory
    {
        IResumeFile GetResumeFile(DocumentType documentType, IStopwordsFile stopwords, byte[] bytes);
        IResumeFile GetResumeFile(DocumentType documentType, IStopwordsFile stopwords, string path);
        IStopwordsFile GetStopwordsFile(DocumentType documentType, List<Stopword> words);
        IStopwordsFile GetStopwordsFile(DocumentType documentType, string path);
    }
    public class FileFactory : IFileFactory
    {
        
        private IFilePreprocessFactory preprocessFactory;
        private IDocumentReaderFactory readerFactory;

        public FileFactory() : this(new FilePreprocessFactory(), new DocumentReaderFactory())
        {
        }
        public FileFactory(IFilePreprocessFactory preprocessFactory, IDocumentReaderFactory readerFactory)
        {
            this.preprocessFactory = preprocessFactory;
            this.readerFactory = readerFactory;
        }

        public IResumeFile GetResumeFile(DocumentType documentType, IStopwordsFile stopwords, byte[] bytes)
        {
            return new ResumeFile(bytes, documentType, stopwords, preprocessFactory, readerFactory);
        }

        public IResumeFile GetResumeFile(DocumentType documentType, IStopwordsFile stopwords, string path)
        {
            return new ResumeFile(path, documentType, stopwords, preprocessFactory, readerFactory);
        }

        public IStopwordsFile GetStopwordsFile(DocumentType documentType, List<Stopword> words)
        {
            return new StopwordsFile(words, documentType);
        }

        public IStopwordsFile GetStopwordsFile(DocumentType documentType, string path)
        {
            return new StopwordsFile(path, documentType, preprocessFactory, readerFactory);
        }
    }
}