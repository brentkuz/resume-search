/*
 * Author: Brent Kuzmanich
 * Comment: Abstract base class for OpenNLP objects
 */

namespace ResumeSearch.NLP
{
    public abstract class OpenNLPBase
    {
        protected string modelPath;
        public OpenNLPBase(Language language)
        {
            Language = language;
        }
        public Language Language { get; private set; }


    }
}
