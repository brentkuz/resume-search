/*
 * Author: Brent Kuzmanich
 * Comment: Interface defining methods for stemming words.
 */


namespace ResumeSearch.NLP.Stemming
{
    /// <summary>
    /// Defines methods for stemming words.
    /// </summary>
    public interface IStemmer
    {
        /// <summary>
        /// Defines a method for stemming a word.
        /// </summary>
        /// <param name="word">Word to stem.</param>
        /// <returns>Stemmed word.</returns>
        string Stem(string word);
    }
}
