using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Tokenizing
{
    public interface ITokenizer
    {
        IEnumerable<string> Tokenize(string text);
    }
}
