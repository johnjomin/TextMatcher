using Xunit;
using TextMatcher.Application.Abstractions;
using TextMatcher.Infrastructure;

namespace TextMatcher.Tests
{
    public class TextMatcherServiceTests
    {
        private readonly ITextMatcherService _textMatcher;
        private readonly string _sampleText;

        public TextMatcherServiceTests()
        {
            _textMatcher = new TextMatcherService();
            _sampleText = "How much wood would a woodchuck chuck if  a woodchuck could chuck wood?";
        }

        [Fact]
        public void FindAllMatches_How_ReturnsPosition1()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "How");

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0]);
        }

        [Fact]
        public void FindAllMatches_wood_ReturnsPositions10_23_45_67()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "wood");

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Equal(10, result[0]);
            Assert.Equal(23, result[1]);
            Assert.Equal(45, result[2]);
            Assert.Equal(67, result[3]);
        }

        [Fact]
        public void FindAllMatches_Wood_ReturnsPositions10_23_45_67()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "Wood");

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Equal(10, result[0]);
            Assert.Equal(23, result[1]);
            Assert.Equal(45, result[2]);
            Assert.Equal(67, result[3]);
        }

        [Fact]
        public void FindAllMatches_oo_ReturnsPositions11_24_46_68()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "oo");

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Equal(11, result[0]);
            Assert.Equal(24, result[1]);
            Assert.Equal(46, result[2]);
            Assert.Equal(68, result[3]);
        }

        [Fact]
        public void FindAllMatches_oO_ReturnsPositions11_24_46_68()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "oO");

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Equal(11, result[0]);
            Assert.Equal(24, result[1]);
            Assert.Equal(46, result[2]);
            Assert.Equal(68, result[3]);
        }

        [Fact]
        public void FindAllMatches_wooden_ReturnsEmptyList()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "wooden");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindAllMatches_QuestionMark_ReturnsPosition71()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "?");

            // Assert
            Assert.Single(result);
            Assert.Equal(71, result[0]);
        }

        [Fact]
        public void FindAllMatches_x_ReturnsEmptyList()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "x");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindAllMatches_EmptySubtext_ReturnsEmptyList()
        {
            // Act
            var result = _textMatcher.FindAllMatches(_sampleText, "");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindAllMatches_EmptyText_ReturnsEmptyList()
        {
            // Act
            var result = _textMatcher.FindAllMatches("", "wood");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindAllMatches_SubtextLongerThanText_ReturnsEmptyList()
        {
            // Act
            var result = _textMatcher.FindAllMatches("short", "very long subtext");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FindAllMatches_OverlappingMatches_ReturnsAllPositions()
        {
            // Arrange
            string text = "oooo";
            string subtext = "ooo";

            // Act
            var result = _textMatcher.FindAllMatches(text, subtext);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
        }

        [Fact]
        public void FindAllMatches_CaseInsensitive_ReturnsAllMatches()
        {
            // Arrange
            string text = "Hello HELLO hello";
            string subtext = "hello";

            // Act
            var result = _textMatcher.FindAllMatches(text, subtext);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(1, result[0]);
            Assert.Equal(7, result[1]);
            Assert.Equal(13, result[2]);
        }

        [Fact]
        public void FindAllMatches_SingleCharacter_ReturnsAllOccurrences()
        {
            // Arrange
            string text = "hello world";
            string subtext = "l";

            // Act
            var result = _textMatcher.FindAllMatches(text, subtext);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(3, result[0]);
            Assert.Equal(4, result[1]);
            Assert.Equal(10, result[2]);
        }

        [Fact]
        public void FindAllMatches_ExactMatch_ReturnsPosition1()
        {
            // Arrange
            string text = "exact";
            string subtext = "exact";

            // Act
            var result = _textMatcher.FindAllMatches(text, subtext);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0]);
        }

        [Fact]
        public void FindAllMatches_NoMatch_ReturnsEmptyList()
        {
            // Arrange
            string text = "hello world";
            string subtext = "xyz";

            // Act
            var result = _textMatcher.FindAllMatches(text, subtext);

            // Assert
            Assert.Empty(result);
        }
    }
}
