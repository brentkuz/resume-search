using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeSearch.Web.Core.Utility
{
    public static class Extensions
    {

        public static byte[] GetBytes(this HttpPostedFileBase file)
        {
            using (var inStr = file.InputStream)
            {
                byte[] bytes;
                var memStr = inStr as System.IO.MemoryStream;
                if (memStr == null)
                {
                    memStr = new System.IO.MemoryStream();
                    inStr.CopyTo(memStr);
                }
                bytes = memStr.ToArray();
                memStr.Dispose();
                return bytes;
            }
        }
    }
}