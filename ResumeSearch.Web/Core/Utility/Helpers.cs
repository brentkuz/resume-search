using ResumeSearch.Web.Core.Logic.BusinessObjects.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ResumeSearch.Web.Core.Utility
{
    public static class Helpers
    {
        public static string GetProjectDir()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var bin = dir.IndexOf("bin");
            if (bin > 0)
            {
                dir = dir.Substring(0, bin);
            }
            return dir;
        }
        
        #region Document Types
        private static Dictionary<string, DocumentType> typeMap = new Dictionary<string, DocumentType>()
        {
            { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", DocumentType.Word },
            { "text/plain", DocumentType.Text }
        };
        public static DocumentType GetWebUploadType(string mimeType)
        {
            if (!typeMap.Keys.Contains(mimeType))
                throw new ArgumentException("File type not supported: " + mimeType);
            return typeMap[mimeType];
        }
        private static Dictionary<string, DocumentType> extMap = new Dictionary<string, DocumentType>
        {
            { "txt", DocumentType.Text },
            { "doc", DocumentType.Word },
            { "docx", DocumentType.Word }
        };
        public static DocumentType ResolvePathToType(string path)
        {
            var name = path.Split('\\').Last();
            var ext = name.Split('.').Last();
            return ResolveExtensionToType(ext);
        }
        public static DocumentType ResolveExtensionToType(string extension)
        {
            if (!extMap.Keys.Contains(extension))
                throw new ArgumentException("File extension not supported: " + extension);
            return extMap[extension];
        }
        #endregion

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

       
    }
}