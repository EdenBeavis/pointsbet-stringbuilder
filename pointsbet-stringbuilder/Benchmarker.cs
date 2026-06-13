using BenchmarkDotNet.Attributes;
using System.Text;

namespace pointsbet_stringbuilder
{
    [MemoryDiagnoser]
    public class Benchmarker
    {
        public static IEnumerable<object[]> GetAlotOfTestCases()
        {
            var count = 100000;
            var items = new string[count];

            var expectedBuilder = new StringBuilder(count * 14);
            var quote = "\"";

            for (int i = 0; i < count; i++)
            {
                items[i] = $"item-{i}";
                expectedBuilder.Append(quote).Append(items[i]).Append(quote);

                if (i < count - 1)
                {
                    expectedBuilder.Append(", ");
                }
            }

            yield return new object[] { items, quote, expectedBuilder.ToString() };
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetAlotOfTestCases))]
        public string Original(string[] items, string quote, string expected)
        {
            return StringFormatterOriginal.ToCommaSepatatedList(items, quote);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetAlotOfTestCases))]
        public string Refactor(string[] items, string quote, string expected)
        {
            return StringFormatterRefactored.ToCommaSeparatedString(items, quote);
        }

        [Benchmark]
        [ArgumentsSource(nameof(GetAlotOfTestCases))]
        public string FurtherOptimised(string[] items, string quote, string expected)
        {
            return ToCommaSeparatedList_FurtherOptimised(items, quote);
        }

        // Didn't want to add this to its own file becuase I didn't want to confuse this as the desired refactor.
        public static string ToCommaSeparatedList_FurtherOptimised(string[] items, string quote)
        {
            if (items == null || items.Length == 0)
                return string.Empty;


            return $"{quote}{string.Join($"{quote}, {quote}", items)}{quote}";
        }
    }
}
