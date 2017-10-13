using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using ResumeSearch.Web.Core.Logic.NLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Files
{    
    public interface IFilePreprocessFactory
    {
        IFilePreprocess GetPreprocess(FileType fileType, IStopwordsFile stopwords = null);
    }
    public class FilePreprocessFactory : IFilePreprocessFactory
    {
        private ITextProcessor textProcessor;
        
        public FilePreprocessFactory(ITextProcessor textProcessor)
        {
            this.textProcessor = textProcessor;
        }
        public IFilePreprocess GetPreprocess(FileType fileType, IStopwordsFile stopwords = null)
        {
            Validate(stopwords, fileType);
            switch (fileType)
            {
                case FileType.Resume:
                    return new ResumePreprocess(stopwords, textProcessor);
                case FileType.Stopwords:
                    return new StopwardsPreprocess(textProcessor);
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
