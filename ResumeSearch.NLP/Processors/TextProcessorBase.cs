/*
 * Author: Brent Kuzmanich
 * Comment: Abstract base class for text processing.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSearch.NLP.Processors
{
    /// <summary>
    /// Abstract class for text processing.
    /// </summary>
    public abstract class TextProcessorBase
    {
        public TextProcessorBase(Language language)
        {
            Language = language;
        }
        public Language Language { get; private set; }
    }
}
