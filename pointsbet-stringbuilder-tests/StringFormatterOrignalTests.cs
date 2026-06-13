using FluentAssertions;
using pointsbet_stringbuilder;

namespace pointsbet_stringbuilder_tests
{
    public class StringFormatterOrignalTests : StringFormatterTestBase
    {
        [Theory]
        [MemberData(nameof(GetSafeCases))]
        [MemberData(nameof(GetArrayItemsVariantCases))]
        [MemberData(nameof(GetArrayItemsNullCases))]
        [MemberData(nameof(GetQuoteVariantCases))]
        [MemberData(nameof(GetQuoteNullCases))]
        [MemberData(nameof(GetWhiteSpaceQuotesAndArrayItemsCases))]
        public void OriginalCode_WhenAllInputsAreValid_ReturnExpectedResult(string[] items, string quote, string expected)
        {
            var result = StringFormatterOriginal.ToCommaSepatatedList(items, quote);

            result.Should().Be(expected);
        }

        [Fact]       
        public void OriginalCode_WhenArrayIsEmpty_ShouldThrowIndexOutOfRangeException()
        {
            Action act = () => StringFormatterOriginal.ToCommaSepatatedList([], "\"");

            act.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void OriginalCode_WhenArrayIsNull_ShouldThrowNullException()
        {
            Action act = () => StringFormatterOriginal.ToCommaSepatatedList(null!, "\"");

            act.Should().Throw<NullReferenceException>();
        }
    }
}
