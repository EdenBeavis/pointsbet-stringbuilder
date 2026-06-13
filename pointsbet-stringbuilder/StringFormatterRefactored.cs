using System;
using System.Collections.Generic;
using System.Text;

namespace pointsbet_stringbuilder
{
    public class StringFormatterRefactored
    {
        private const string Separator = ", ";

        public static string ToCommaSeparatedString(string[] items, string quote)
        {
            if (items == null || items.Length == 0)
                return string.Empty;

            return string.Join(Separator, items.Select(item => $"{quote}{item}{quote}"));
        }
    }
}
