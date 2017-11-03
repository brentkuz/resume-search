using ResumeSearch.Crosscutting.Entities;
using ResumeSearch.Crosscutting.Enums;
using ResumeSearch.NLP;
using ResumeSearch.Web.Core.Logic.DocumentReaders;
using ResumeSearch.Web.Core.Logic.Preprocess;
using ResumeSearch.Web.Core.Logic.Preprocess.Files;
using System.Collections;
using System.Collections.Generic;

namespace ResumeSearch.Web.Core.Logic.BusinessObjects.Files
{
    public interface IStopwordsFile
    {
        bool Exists(string word);
    }
    public class StopwordsFile : FileBase, IStopwordsFile
    {
        public StopwordsFile(string path, DocumentType documentType, IFilePreprocessFactory preprocessFactory, IDocumentReaderFactory readerFactory) 
            : base(path, documentType, FileType.Stopwords)
        {
            var preprocess = preprocessFactory.GetPreprocess(FileType.Stopwords, Language.English);
            using (var rdr = readerFactory.GetFileReader(documentType, path))
            {
                words = preprocess.Process(rdr);
            }

        }
        public StopwordsFile(List<Stopword> wordSet, DocumentType documentType)
            : base("", documentType, FileType.Stopwords)
        {
            foreach(var w in wordSet)
            {
                if (!words.Contains(w.Word))
                    words.Add(w.Word);
            }
        }

    }
}
