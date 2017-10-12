using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.DocumentReaders
{
    public interface IDocumentReaderFactory
    {
        IDocumentReader GetFileReader(DocumentType documentType, string path);
        IDocumentReader GetStreamReader(byte[] content);
    }
    public class DocumentReaderFactory : IDocumentReaderFactory
    {
        public IDocumentReader GetFileReader(DocumentType documentType, string path)
        {
            switch (documentType)
            {
                case DocumentType.Text:
                    return new TextDocumentReader(path);
                case DocumentType.Word:
                    return new WordDocumentReader(path);                
                default:
                    throw new ArgumentException("Factory does not support DocumentType.");
            }
        }

        public IDocumentReader GetStreamReader(byte[] content)
        {
            return new BytesReader(content);
        }
    }
}
