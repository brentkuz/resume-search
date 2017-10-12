﻿
using ResumeSearch.Web.Core.JobAPIs.Listings;
using ResumeSearch.Web.Core.Logic.Preprocess;
using ResumeSearch.Web.Core.Logic.Preprocess.Listings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.Web.Core.Logic.BusinessObjects.Listings
{
    public enum ListingSource
    {
        Github
    }
    public class Listing
    {
        private readonly ListingSource source;
        private HashSet<string> words;

        //Github 
        public Listing(GitHubJob job, GitHubPreprocess preprocess)
        {
            source = ListingSource.Github;
            words = new HashSet<string>();
            Url = job.Url;
            Title = job.Title;
            Location = job.Location;
            Body = job.Body;
            Company = job.Company;
            //Date = Convert.ToDateTime(job.Date);

            words = preprocess.Process(Body);
        }

        public ListingSource Source { get { return source; } }
        public int Rank { get; set; }
        public string Url { get; private set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Body { get; set; }
        public string Company { get; set; }
        public DateTime? Date { get; set; }

        private string ValueOrDefault(string val)
        {
            return (val != string.Empty ? val : "n/a") ?? "n/a";
        }
    }
}