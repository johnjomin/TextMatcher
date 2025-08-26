using System;
using System.Collections.Generic;
using System.Linq;

namespace TextMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Text Matcher Application");
            Console.WriteLine("=======================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Run Demo (with sample data)");
                Console.WriteLine("2. Interactive Mode (input your own text)");
                Console.WriteLine("3. Exit");
                Console.Write("\nEnter your choice (1-3): ");

                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        RunDemo();
                        break;
                    case "2":
                        RunInteractive();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using the Text Matcher!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.\n");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void RunDemo()
        {
            Console.WriteLine("\n=== DEMO MODE ===");
            
            // Sample text and subtexts for demonstration
            string text = "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?";
            
            // List of subtexts to test
            string[] subtexts = { "How", "wood", "Wood", "oo", "oO", "wooden", "?", "x" };

            Console.WriteLine($"Text: {text}");
            Console.WriteLine();
            Console.WriteLine("Subtext\tPositions");
            Console.WriteLine("--------\t----------");

            foreach (string subtext in subtexts)
            {
                var positions = FindAllMatches(text, subtext);
                if (positions.Any())
                {
                    Console.WriteLine($"{subtext}\t{string.Join(",", positions)}");
                }
                else
                {
                    Console.WriteLine($"{subtext}\t");
                }
            }
        }

        static void RunInteractive()
        {
            Console.WriteLine("\n=== INTERACTIVE MODE ===");
            
            while (true)
            {
                try
                {
                    // Get text input from user
                    Console.Write("\nEnter the main text (or 'back' to return to menu): ");
                    string text = Console.ReadLine()?.Trim();
                    
                    if (string.IsNullOrEmpty(text) || text.ToLower() == "back")
                        break;

                    // Get subtext input from user
                    Console.Write("Enter the subtext to search for: ");
                    string subtext = Console.ReadLine()?.Trim();
                    
                    if (string.IsNullOrEmpty(subtext))
                    {
                        Console.WriteLine("Subtext cannot be empty. Please try again.\n");
                        continue;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Text: {text}");
                    Console.WriteLine($"Subtext: {subtext}");
                    Console.WriteLine();

                    // Find all matches
                    var positions = FindAllMatches(text, subtext);
                    
                    if (positions.Any())
                    {
                        Console.WriteLine($"Found {positions.Count} match(es) at position(s): {string.Join(", ", positions)}");
                    }
                    else
                    {
                        Console.WriteLine("No matches found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine("Please try again.\n");
                }
            }
        }

        /// <summary>
        /// Finds all case-insensitive matches of subtext within text and returns their starting positions
        /// </summary>
        /// <param name="text">The main text to search in</param>
        /// <param name="subtext">The subtext to search for</param>
        /// <returns>List of starting positions (1-based indexing)</returns>
        static List<int> FindAllMatches(string text, string subtext)
        {
            var positions = new List<int>();
            
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
                return positions;

            // Convert both strings to lowercase for case-insensitive comparison
            string lowerText = text.ToLower();
            string lowerSubtext = subtext.ToLower();
            
            int position = 0;
            
            // Find all occurrences
            while ((position = lowerText.IndexOf(lowerSubtext, position)) != -1)
            {
                // Add 1 to convert from 0-based to 1-based indexing
                positions.Add(position + 1);
                position += 1; // Move to next position to find overlapping matches
            }
            
            return positions;
        }
    }
}
