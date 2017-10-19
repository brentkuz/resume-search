﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.SentenceDetection
{
    public interface ISentenceDetector
    {
        IEnumerable<string> DetectSentences(string text);
    }
}