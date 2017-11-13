/*
 * Author: Brent Kuzmanich
 * Comment: Class for stemming English words.
 */


namespace ResumeSearch.NLP.Stemming
{
    /// <summary>
    /// Class for stemming English words.
    /// </summary>
    public class EnglishStemmer : OpenNLPBase, IStemmer
    {
        private Accord.MachineLearning.Text.Stemmers.EnglishStemmer stemmer;

        public EnglishStemmer() : base(Language.English)
        {
            stemmer = new Accord.MachineLearning.Text.Stemmers.EnglishStemmer();
        }

        /// <summary>
        /// Method for stemming English words.
        /// </summary>
        /// <param name="word">Word to stem.</param>
        /// <returns>Stemmed word.</returns>
        public string Stem(string word)
        {            
            return stemmer.Stem(word);
        }
    }
}
