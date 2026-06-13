using System.Text;

namespace pointsbet_stringbuilder
{    
    public class StringFormatterOriginal
    {

        // Original implementation for testing comparsion and benchmarking
        public static string ToCommaSepatatedList(string[] items, string quote)
        {
            StringBuilder qry = new StringBuilder(string.Format("{0}{1}{0}", quote, items[0]));

            if (items.Length > 1)
            {
                for (int i = 1; i < items.Length; i++)
                {
                    qry.Append(string.Format(", {0}{1}{0}", quote, items[i]));
                }
            }

            return qry.ToString();
        }
    }
}
