using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.DocumentReaders
{

    public interface IDocumentReader : IDisposable
    {
        string ReadLine();
        bool EndOfFile();
    }
}
