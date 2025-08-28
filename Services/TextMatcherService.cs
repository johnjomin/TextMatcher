using System.Collections.Generic;
using TextMatcher.Application.Abstractions;

namespace TextMatcher.Infrastructure
{
    /// <summary>
    /// implementation of the text matching service
    /// </summary>
    public class TextMatcherService : ITextMatcherService
    {
        /// <summary>
        /// Finds all case-insensitive matches of subtext within text
        /// </summary>
        /// <param name="text">The main text to search in</param>
        /// <param name="subtext">The subtext to search for</param>
        /// <returns>List of starting positions</returns>
        public List<int> FindAllMatches(string text, string subtext)
        {
            var matchPositions = new List<int>();
            
            // quick sanity checks
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
                return matchPositions;

            if (subtext.Length > text.Length)
                return matchPositions;

            // Manual character-by-character search
            for (int i = 0; i <= text.Length - subtext.Length; i++)
            {
                if (IsMatchAtPosition(text, subtext, i))
                {
                    // +1 because positions are 1-based
                    matchPositions.Add(i + 1);
                }
            }
            
            return matchPositions;
        }

        /// <summary>
        /// check if subtext matches text starting at this position
        /// </summary>
        /// <param name="text">The main text</param>
        /// <param name="subtext">The subtext to match</param>
        /// <param name="position">The position to check</param>
        /// <returns>True if there's a match</returns>
        private bool IsMatchAtPosition(string text, string subtext, int position)
        {
            for (int j = 0; j < subtext.Length; j++)
            {
                if (!AreCharactersEqual(text[position + j], subtext[j]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Quick manual case-insensitive comparison
        /// </summary>
        /// <param name="char1">first character</param>
        /// <param name="char2">second character</param>
        /// <returns>True if characters are equal</returns>
        private bool AreCharactersEqual(char char1, char char2)
        {
            return ToLower(char1) == ToLower(char2);
        }

        // only handles A-Z → a-z (ASCII)
        private char ToLower(char c)
        {
            // if character is uppercase and convert to lowercase
            if (c >= 'A' && c <= 'Z')
                return (char)(c + 32);
            return c;
        }
    }
}
