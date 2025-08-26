# Text Matcher Application

A C# .NET Core console application that finds all case-insensitive matches of a subtext within a given text and returns their character positions.

## Features

- **Case-insensitive matching**: Finds matches regardless of letter case
- **Multiple matches**: Returns all occurrences of the subtext within the text
- **1-based indexing**: Character positions start from 1 (not 0)
- **Overlapping matches**: Can find overlapping subtext matches
- **Input validation**: Handles empty strings and edge cases gracefully
- **Dual modes**: Demo mode with sample data and interactive mode for custom input

## Requirements

- .NET Core 6.0 or later
- Windows, macOS, or Linux

## How to Run

```bash
dotnet run
```

The application will present you with a menu:
1. **Demo Mode**: Runs with the sample text and predefined subtexts
2. **Interactive Mode**: Allows you to input your own text and subtext
3. **Exit**: Closes the application

## Sample Output

Using the sample text: "How much wood would a Woodchuck chuck, if a Woodchuck could chuck wood?"

| Subtext | Positions |
|---------|-----------|
| How     | 1         |
| wood    | 10,23,45,67 |
| Wood    | 10,23,45,67 |
| oo      | 11,24,46,68 |
| oO      | 11,24,46,68 |
| wooden  |           |
| ?       | 71        |
| x       |           |

## How It Works

1. **Input**: Accepts two strings - "Text" (main text) and "Subtext" (text to search for)
2. **Processing**: Converts both strings to lowercase for case-insensitive comparison
3. **Search**: Uses `IndexOf` method to find all occurrences
4. **Output**: Returns a list of starting positions (1-based indexing)

## Algorithm Details

- The application uses the `String.IndexOf` method to find matches
- It handles overlapping matches by incrementing the search position by 1 after each match
- All positions are converted from 0-based to 1-based indexing for user-friendly output
- Empty strings and null values are handled gracefully

## Building the Application

```bash
dotnet build
```

## Project Structure

- `Program.cs` - Main program with both demo and interactive modes
- `TextMatcher.csproj` - Project file
- `README.md` - This documentation file

## Example Usage

### Demo Mode
Automatically runs with the sample text and shows results for predefined subtexts.

### Interactive Mode
1. Choose option 2 from the main menu
2. Enter your main text
3. Enter the subtext to search for
4. View the results
5. Type 'back' to return to the main menu

## Notes

- The application is designed to be simple and efficient
- It handles edge cases like empty strings and null values
- The search is case-insensitive as per requirements
- All character positions are 1-based for better user experience
- The interactive mode allows for unlimited custom searches
- Type 'back' in interactive mode to return to the main menu
