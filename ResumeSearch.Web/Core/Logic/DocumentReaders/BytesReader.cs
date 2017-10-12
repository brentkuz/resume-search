using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Logic.DocumentReaders
{
    public class BytesReader : IDocumentReader
    {
        private bool disposed = false;
        private byte[] bytes;
        private StreamReader reader;
        public BytesReader(byte[] bytes)
        {
            this.bytes = bytes;
            reader = new StreamReader(new MemoryStream(bytes));
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