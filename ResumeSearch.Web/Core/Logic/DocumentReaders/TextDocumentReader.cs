using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.DocumentReaders
{
    public class TextDocumentReader : IDocumentReader
    {
        private bool disposed = false;
        private string path;
        private StreamReader reader;

        public TextDocumentReader(string path)
        {
            if(!File.Exists(path))
                throw new FileNotFoundException("Could not find text document.", path);
            this.path = path;
            reader = new StreamReader(path);
        }


        public bool EndOfFile()
        {
            if (reader != null)
                return reader.EndOfStream;
            return true;
        }

        public string ReadLine()
        {
            if (reader == null || EndOfFile())
                throw new EndOfStreamException("The reader either closed or the end of file was reached.");
            return reader.ReadLine();
        }


        protected void Dispose(bool disposing)
        {
            if(disposing && !disposed)
            {
                reader.Close();
                reader.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
