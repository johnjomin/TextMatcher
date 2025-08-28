using System.Collections.Generic;
using TextMatcher.Application.Abstractions;

namespace TextMatcher.Infrastructure
{
    /// <summary>
    /// Implementation of the text matching service with manual character-by-character comparison
    /// </summary>
    public class TextMatcherService : ITextMatcherService
    {
        /// <summary>
        /// Finds all case-insensitive matches of subtext within text and returns their starting positions
        /// </summary>
        /// <param name="text">The main text to search in</param>
        /// <param name="subtext">The subtext to search for</param>
        /// <returns>List of starting positions (1-based indexing)</returns>
        public List<int> FindAllMatches(string text, string subtext)
        {
            var positions = new List<int>();
            
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
                return positions;

            if (subtext.Length > text.Length)
                return positions;

            // Manual character-by-character search
            for (int i = 0; i <= text.Length - subtext.Length; i++)
            {
                if (IsMatchAtPosition(text, subtext, i))
                {
                    // Add 1 to convert from 0-based to 1-based indexing
                    positions.Add(i + 1);
                }
            }
            
            return positions;
        }

        /// <summary>
        /// Checks if subtext matches at the specified position in text
        /// </summary>
        /// <param name="text">The main text</param>
        /// <param name="subtext">The subtext to match</param>
        /// <param name="position">The position to check</param>
        /// <returns>True if there's a match, false otherwise</returns>
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
        /// Performs case-insensitive character comparison manually
        /// </summary>
        /// <param name="char1">First character</param>
        /// <param name="char2">Second character</param>
        /// <returns>True if characters are equal (case-insensitive), false otherwise</returns>
        private bool AreCharactersEqual(char char1, char char2)
        {
            // Manual case-insensitive comparison
            char lowerChar1 = ToLower(char1);
            char lowerChar2 = ToLower(char2);
            return lowerChar1 == lowerChar2;
        }

        /// <summary>
        /// Converts a character to lowercase manually using ASCII arithmetic
        /// </summary>
        /// <param name="c">Character to convert</param>
        /// <returns>Lowercase character</returns>
        private char ToLower(char c)
        {
            // Check if character is uppercase (ASCII 65-90) and convert to lowercase
            if (c >= 'A' && c <= 'Z')
            {
                return (char)(c + 32);
            }
            return c;
        }
    }
}
