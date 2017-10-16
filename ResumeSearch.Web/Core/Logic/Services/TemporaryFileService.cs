using ResumeSearch.Web.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;

namespace ResumeSearch.Web.Core.Logic.Services
{
    public interface ITemporaryFileService
    {
        string CreateTempFile(HttpPostedFileBase file);
        string CreateTempFile(byte[] bytes, string fileName, int contentLength);
        void DeleteTempFile(string path);
    }
    public class TemporaryFileService : ITemporaryFileService
    {
        public string CreateTempFile(HttpPostedFileBase file)
        {
            var name = Guid.NewGuid().ToString() + "_" + file.FileName;
            var path = HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["TempPath"]) + "\\" + name;
            using (var strm = File.OpenWrite(path))
            {
                var length = file.ContentLength;
                var bytes = file.GetBytes();
                if (bytes == null)
                    throw new NullReferenceException("Could not retrieve bytes from upload");
                strm.Write(bytes, 0, length);
                strm.Close();
            }
            return path;
        }
        public string CreateTempFile(byte[] bytes, string fileName, int contentLength)
        {
            var name = Guid.NewGuid().ToString() + "_" + fileName;
            var path = HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["TempPath"]) + "\\" + name;
            using (var strm = File.OpenWrite(path))
            {
                if (bytes == null)
                    throw new NullReferenceException("Could not retrieve bytes from upload");
                strm.Write(bytes, 0, contentLength);
                strm.Close();
            }
            return path;
        }
        public void DeleteTempFile(string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}