using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.DocumentReaders
{
    public class WordDocumentReader : IDocumentReader
    {
        private bool disposed = false;
        private int paraIdx = 0;
        private Application word;
        private Document doc;
        private int docParaCnt;

        public WordDocumentReader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File was not found.", path);

            word = new Application();            
            doc = new Document();

            object fileName = path;
            object missing = System.Type.Missing;
            doc = word.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            docParaCnt = doc.Paragraphs.Count;
        }

        public bool EndOfFile()
        {
            if (word == null || doc == null)
                return true;
            return paraIdx >= docParaCnt;
        }

        public string ReadLine()
        {
            if(word == null || doc == null || EndOfFile())
                throw new EndOfStreamException("The reader either closed or the end of file was reached.");
            return doc.Paragraphs[paraIdx++ + 1].Range.Text.Trim();           
        }

        protected void Dispose(bool disposing)
        {
            if(disposing && ! disposed)
            {
                ((_Document)doc).Close();
                ((_Application)word).Quit();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
