using TextMatcher.Application.Abstractions;
using TextMatcher.Infrastructure;

namespace TextMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextMatcherService textMatcher = new TextMatcherService();
            
            // Text from the requirements
            string requirementText = "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?";
            
            // Test cases from the requirements
            string[] subtexts = { "How", "wood", "Wood", "oo", "oO", "wooden", "?", "x" };
            
            Console.WriteLine("Subtext : Positions");
            
            foreach (var sub in subtexts)
            {
                var positions = textMatcher.FindAllMatches(requirementText, sub);
                // sure can be converted into one line but this way, better readability :D
                if (positions.Count == 0)
                    Console.WriteLine($"{sub}");
                else
                    Console.WriteLine($"{sub} : {string.Join(",", positions)}");
            }
        }
    }
}
