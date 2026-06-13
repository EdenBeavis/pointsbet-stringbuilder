using FluentAssertions;
using pointsbet_stringbuilder;

namespace pointsbet_stringbuilder_tests
{
    public class StringFormatterRefactorTests : StringFormatterTestBase
    {
        [Theory]
        [MemberData(nameof(GetSafeCases))]
        [MemberData(nameof(GetArrayItemsVariantCases))]
        [MemberData(nameof(GetArrayItemsNullCases))]
        [MemberData(nameof(GetQuoteVariantCases))]
        [MemberData(nameof(GetQuoteNullCases))]
        [MemberData(nameof(GetWhiteSpaceQuotesAndArrayItemsCases))]
        public void Refactored_WhenAllInputsAreValid_ReturnExpectedResult(string[] items, string quote, string expected)
        {
            var result = StringFormatterRefactored.ToCommaSeparatedString(items, quote);

            result.Should().Be(expected);
        }

        // Original unhappy path throws exceptions, refactored and optimised return empty string.
        // This is a "difference" in execution but I think it's the right one to make.
        [Fact]
        public void Refactored_WhenArrayIsEmpty_ReturnsEmptyString()
        {
            var result = StringFormatterRefactored.ToCommaSeparatedString([], "\"");

            result.Should().Be(string.Empty);
        }

        [Fact]
        public void Refactored_WhenArrayIsNull_ReturnsEmptyString()
        {
            var result = StringFormatterRefactored.ToCommaSeparatedString(null!, "\"");

            result.Should().Be(string.Empty);
        }
    }
}
