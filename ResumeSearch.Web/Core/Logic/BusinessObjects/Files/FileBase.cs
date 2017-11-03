using ResumeSearch.Crosscutting.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.BusinessObjects.Files
{


    public abstract class FileBase
    {
        private readonly DocumentType documentType;
        private readonly FileType fileType;
        private string path;
        protected HashSet<string> words;
        internal FileBase(string path, DocumentType documentType, FileType fileType)
        {
            if ((documentType != DocumentType.Bytes && documentType != DocumentType.Set) && !File.Exists(path))
                throw new FileNotFoundException("The stopword file was not found.", path);
            this.path = path;
            this.documentType = documentType;
            this.fileType = fileType;
            words = new HashSet<string>();
        }
        public string Path { get { return path; } }
        public DocumentType DocumentType { get { return documentType; } }
        public FileType FileType { get { return fileType; } }
        public HashSet<string> Words
        {
            get { return words; }
            protected set { words = value; }
        }
        public bool Exists(string word)
        {
            return words.Contains(word.ToLower());
        }
  
    }
}
