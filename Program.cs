using TextMatcher.Application.Abstractions;
using TextMatcher.Infrastructure;

namespace TextMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the text matcher service directly
            ITextMatcherService textMatcher = new TextMatcherService();
            
            // Sample text from the requirements
            string sampleText = "How much wood would a woodchuck chuck if  a woodchuck could chuck wood?";
            
            // Test cases from the requirements
            string[] subtexts = { "How", "wood", "Wood", "oo", "oO", "wooden", "?", "x" };
            
            Console.WriteLine("Subtext Positions");
            
            foreach (string subtext in subtexts)
            {
                var positions = textMatcher.FindAllMatches(sampleText, subtext);
                
                if (positions.Count == 0)
                {
                    Console.WriteLine($"{subtext}");
                }
                else
                {
                    string positionsStr = string.Join(",", positions);
                    Console.WriteLine($"{subtext} {positionsStr}");
                }
            }
        }
    }
}
