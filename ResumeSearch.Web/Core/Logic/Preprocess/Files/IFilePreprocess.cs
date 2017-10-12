using ResumeSearch.Web.Core.Logic.DocumentReaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Files
{
    public interface IFilePreprocess
    {
        HashSet<string> Process(IDocumentReader stream);
    }
}
