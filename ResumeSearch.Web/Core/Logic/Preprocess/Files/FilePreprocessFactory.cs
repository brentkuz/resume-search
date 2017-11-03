using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeSearch.NLP.Processors;
using ResumeSearch.NLP;
using ResumeSearch.Crosscutting.Enums;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Files
{    
    public interface IFilePreprocessFactory
    {
        IFilePreprocess GetPreprocess(FileType fileType, Language language, IStopwordsFile stopwords = null);
    }
    public class FilePreprocessFactory : IFilePreprocessFactory
    {
        private ITextProcessorFactory procFact;
        
        public FilePreprocessFactory(ITextProcessorFactory procFact)
        {
            this.procFact = procFact;
        }
        public IFilePreprocess GetPreprocess(FileType fileType, Language language, IStopwordsFile stopwords = null)
        {
            Validate(stopwords, fileType);
            switch (fileType)
            {
                case FileType.Resume:
                    return new ResumePreprocess(stopwords, procFact.GetTextProcessor(language));
                case FileType.Stopwords:
                    return new StopwardsPreprocess(procFact.GetTextProcessor(language));
                default:
                    throw new Exception("Failed to instantiate file preprocess.");
            }
        }

        private void Validate(IStopwordsFile stopwords, FileType fileType)
        {
            if (stopwords == null && (fileType == FileType.Resume))
            {
                throw new ArgumentNullException("Stopwords are required to preprocess file: {0}.", fileType.ToString());
            }
        }

    }
}
