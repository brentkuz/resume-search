using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.Preprocess.Listings
{
    public interface IListingPreprocess
    {
         HashSet<string> Process(string body);        
    }
}
