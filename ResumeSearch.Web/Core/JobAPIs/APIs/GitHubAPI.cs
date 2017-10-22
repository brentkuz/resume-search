using Newtonsoft.Json;
using ResumeSearch.Web.Core.JobAPIs.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ResumeSearch.Web.Core.JobAPIs.APIs
{
    public interface IGitHubAPI
    {
        Task<List<GitHubJob>> Search(string search, string location, bool fullTime);
    }
    public class GitHubAPI : JobAPIBase, IGitHubAPI
    {
        public GitHubAPI()
        {
            baseUrl = "https://jobs.github.com/positions.json";
        }
        public async Task<List<GitHubJob>> Search(string search, string location, bool fullTime)
        {            
            
            var url = Uri.EscapeUriString(baseUrl + "?" + BuildQueryString(search, location, fullTime));
            using (var http = new HttpClient())
            using(HttpResponseMessage response = await http.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<List<GitHubJob>>(responseBody);
                return res;
            }
        }
        private string BuildQueryString(string search, string location, bool fullTime)
        {
            StringBuilder sb = new StringBuilder();
            if (search != null && search != string.Empty)            
                sb.Append("description=" + EncodeSpecialCharacters(search));
            if (location != null && location != string.Empty)
            {
                if (sb.ToString() != string.Empty)
                    sb.Append("&");
                sb.Append("location=" + EncodeSpecialCharacters(location));
            }
            if (fullTime == true)
            {
                if (sb.ToString() != string.Empty)
                    sb.Append("&");
                sb.Append("full_time=" + fullTime.ToString());
            }

            return sb.ToString();
        }
    }
}
