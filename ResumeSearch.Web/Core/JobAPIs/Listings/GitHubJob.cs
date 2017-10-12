
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.JobAPIs.Listings
{
    public class GitHubJob
    {
        public GitHubJob()
        {
        }
        public GitHubJob(string url, string title, string location, string body, string company, string date)
        {
            Url = url;
            Title = title;
            Location = location;
            Body = body;
            Company = company;
            Date = date;
        }
        [JsonProperty("url")]
        public string Url { get; private set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("description")]
        public string Body { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("created_at")]
        public string Date { get; set; }
    }
}
