using System.Collections.Generic;

namespace TextMatcher.Application.Abstractions
{
    /// <summary>
    /// Service interface for finding text matches
    /// </summary>
    public interface ITextMatcherService
    {
        List<int> FindAllMatches(string text, string subtext);
    }
}
