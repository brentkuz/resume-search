
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.Preprocess;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ResumeSearch.Web.Core.Data.Entities;
using ResumeSearch.NLP;

namespace ResumeSearch.Web.Core.Logic.BusinessObjects.Files
{
    public interface IResumeFile : IEnumerable
    {
        bool Exists(string word);
    }
    public class ResumeFile : FileBase, IResumeFile
    {
        public ResumeFile(string path, DocumentType documentType, IStopwordsFile stopwords, IFilePreprocessFactory preprocessFactory, IDocumentReaderFactory readerFactory) 
            : base(path, documentType, FileType.Resume)
        {
            var preprocess = preprocessFactory.GetPreprocess(FileType.Resume, Language.English, stopwords);
            using (var rdr = readerFactory.GetFileReader(documentType, path))
            {
                words = preprocess.Process(rdr);
            }
        }
        public ResumeFile(byte[] content, DocumentType documentType, IStopwordsFile stopwords, IFilePreprocessFactory preprocessFactory, IDocumentReaderFactory readerFactory)
            : base("", documentType, FileType.Resume)
        {
            Content = content;
            var preprocess = preprocessFactory.GetPreprocess(FileType.Resume, Language.English, stopwords);
            using (var rdr = readerFactory.GetStreamReader(content))
            {
                words = preprocess.Process(rdr);
            }
        }
        public ResumeFile(Resume entity) : base("", DocumentType.Bytes, FileType.Resume)
        {
            Content = entity.Content;
            var set = new HashSet<string>();
            foreach(var w in entity.Keywords)
                set.Add(w.Word);
            Words = set;
        }

        public byte[] Content { get; set; }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        } 

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var w in words)
            {
                yield return w;
            }
        }
    }
}
