using System.Collections.Generic;

namespace TextMatcher.Application.Abstractions
{
    /// <summary>
    /// Service interface for finding text matches
    /// </summary>
    public interface ITextMatcherService
    {
        /// <summary>
        /// Finds all case-insensitive matches of subtext within text and returns their starting positions
        /// </summary>
        /// <param name="text">The main text to search in</param>
        /// <param name="subtext">The subtext to search for</param>
        /// <returns>List of starting positions (1-based indexing)</returns>
        List<int> FindAllMatches(string text, string subtext);
    }
}
