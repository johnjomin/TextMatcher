# TextMatcher

A C# console application that implements a text matching algorithm to find all case-insensitive occurrences of a subtext within a larger text, returning their starting positions (1-based indexing).

## Requirements

This solution was built for a job interview coding exercise with strict requirements:

- **Language**: C# (.NET 6+)
- **Project Type**: Console application
- **Core Functionality**: Find all case-insensitive matches of subtext within text
- **Forbidden**: No built-in string helpers like `IndexOf`, `Substring`, `Split`, `Regex`, `ToLower`, `Span`, or any library functions that perform substring matching
- **Required**: Manual character-by-character comparison using loops, arrays, and manual char-to-char comparison
- **Case-insensitive**: Implemented manually using ASCII arithmetic (checking if char is between 'A'-'Z' and adding 32)
- **Overlapping**: Matches must allow overlapping occurrences

## Architecture

The solution follows SOLID principles with a clean architecture:

- **`ITextMatcherService`**: Interface defining the text matching contract
- **`TextMatcherService`**: Implementation with manual character-by-character comparison
- **`Program.cs`**: Simple console application entry point
- **`TextMatcher.Tests`**: xUnit test project with comprehensive test coverage

## Sample Output

The application demonstrates the functionality with the sample text:
> "How much wood would a woodchuck chuck if  a woodchuck could chuck wood?"

Expected output:
```
Subtext Positions
How 1
wood 10,23,45,67
Wood 10,23,45,67
oo 11,24,46,68
oO 11,24,46,68
wooden
? 71
x
```

## Test Cases

The solution includes comprehensive unit tests covering:

### Acceptance Test Cases
- "How" → 1
- "wood" → 10,23,45,67
- "Wood" → 10,23,45,67
- "oo" → 11,24,46,68
- "oO" → 11,24,46,68
- "wooden" → (no matches)
- "?" → 71
- "x" → (no matches)

### Edge Cases
- Empty subtext
- Empty text
- Subtext longer than text
- Overlapping matches
- Case-insensitive matching
- Single character matching
- Exact matches
- No matches

## Build and Run Instructions

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022, VS Code, or any .NET-compatible IDE

### Build the Application
```bash
dotnet build
```

### Run the Application
```bash
dotnet run --project TextMatcher
```

### Run the Tests
```bash
dotnet test
```

### Run Tests with Coverage (Optional)
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Packaging

To create a ZIP package for submission:

```bash
# Create a ZIP file excluding build artifacts
zip -r CODING_EXERCISE_[INITIALS].zip . -x "*/bin/*" "*/obj/*"
```

Or manually create a ZIP file named `CODING_EXERCISE_[INITIALS].ZIP` containing all project files while excluding the `bin/` and `obj/` directories.

## Project Structure

```
TextMatcher/
├── Application/
│   └── Abstractions/
│       └── ITextMatcherService.cs
├── Infrastructure/
│   └── TextMatcherService.cs
├── TextMatcher.Tests/
│   ├── TextMatcherServiceTests.cs
│   └── TextMatcher.Tests.csproj
├── Program.cs
├── TextMatcher.csproj
└── README.md
```

## Implementation Details

### Manual Character Comparison
The solution implements case-insensitive character comparison manually:

```csharp
private bool AreCharactersEqual(char char1, char char2)
{
    char lowerChar1 = ToLower(char1);
    char lowerChar2 = ToLower(char2);
    return lowerChar1 == lowerChar2;
}

private char ToLower(char c)
{
    if (c >= 'A' && c <= 'Z')
    {
        return (char)(c + 32);
    }
    return c;
}
```

### Manual Substring Search
The algorithm uses nested loops to check each possible starting position:

```csharp
for (int i = 0; i <= text.Length - subtext.Length; i++)
{
    if (IsMatchAtPosition(text, subtext, i))
    {
        positions.Add(i + 1); // Convert to 1-based indexing
    }
}
```

## Performance Characteristics

- **Time Complexity**: O(n × m) where n is text length and m is subtext length
- **Space Complexity**: O(k) where k is the number of matches found
- **Memory**: Minimal overhead, no large string allocations

## Compliance with Requirements

✅ **C# (.NET 6+)** - Targets .NET 6.0  
✅ **Console Application** - Simple Program.cs entry point  
✅ **Manual Implementation** - No built-in string helpers used  
✅ **Case-insensitive** - Manual ASCII arithmetic implementation  
✅ **Overlapping Matches** - Supports overlapping occurrences  
✅ **1-based Indexing** - Returns positions starting from 1  
✅ **SOLID Principles** - Clean architecture with interfaces  
✅ **Unit Tests** - Comprehensive xUnit test coverage  
✅ **Simple Wiring** - No DI container, direct instantiation  

## Notes

- The solution prioritizes correctness and compliance with requirements over performance optimization
- All string operations are implemented manually without using .NET's built-in string methods
- The algorithm handles edge cases gracefully (empty strings, subtext longer than text, etc.)
- Tests cover all acceptance criteria and additional edge cases for robustness
