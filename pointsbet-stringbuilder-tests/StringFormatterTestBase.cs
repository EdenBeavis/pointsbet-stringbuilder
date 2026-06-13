using System;
using System.Collections.Generic;
using System.Text;

namespace pointsbet_stringbuilder_tests
{
    public class StringFormatterTestBase
    {
        public static TheoryData<string[], string, string> GetArrayItemsVariantCases() => 
            new ()
            {
                { ["pot\"ato", "cakes", "aregood"], "\"", "\"pot\"ato\", \"cakes\", \"aregood\"" },
                { ["\"", "\"", "\""], "\"", "\"\"\", \"\"\", \"\"\"" },
                { [",", ",", ",,,,"], "\"", "\",\", \",\", \",,,,\"" },
                { ["potato, cakes", "aregood"], "\"", "\"potato, cakes\", \"aregood\"" },
            };

        public static TheoryData<string[], string, string> GetArrayItemsNullCases() =>
            new()
            {
                { ["potato", "cakes", null!], "\"", "\"potato\", \"cakes\", \"\"" }, 
                { [null!, "cakes", null!], "\"", "\"\", \"cakes\", \"\"" }
            };

        public static TheoryData<string[], string, string> GetQuoteVariantCases() =>
            new()
            {
                { ["potato", "cakes", "aregood"], "'", "'potato', 'cakes', 'aregood'" },
                { ["potato", "cakes", "aregood"], "-", "-potato-, -cakes-, -aregood-" },
                { ["potato", "cakes", "aregood"], ";", ";potato;, ;cakes;, ;aregood;" },
                { ["potato", "cakes", "aregood"], ",", ",potato,, ,cakes,, ,aregood," }, // Quote matches separator
                { ["potato", "cakes", "aregood"], "<b>", "<b>potato<b>, <b>cakes<b>, <b>aregood<b>" },
                { ["potato", "cakes", "aregood"], "", "potato, cakes, aregood" }
            };

        public static TheoryData<string[], string, string> GetQuoteNullCases() =>
            new()
            {
                { ["potato", "cakes", "aregood"], null!, "potato, cakes, aregood" }
            };

        public static TheoryData<string[], string, string> GetWhiteSpaceQuotesAndArrayItemsCases() =>
            new()
            {
                { [" ", "  ", "  "], "\"", "\" \", \"  \", \"  \"" },
                { ["potato", "cakes", "aregood"], " ", " potato ,  cakes ,  aregood " },
                { [" ", "  ", "  "], " ", "   ,     ,     " },
            };

        public static TheoryData<string[], string, string> GetSafeCases() =>
            new()
            {
                { ["potato"], "\"", "\"potato\"" },
                { ["potato", "cakes"], "\"", "\"potato\", \"cakes\"" },
                { ["potato", "cakes", "aregood"], "\"", "\"potato\", \"cakes\", \"aregood\"" },
                {
                    [
                        "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon",
                        "mango", "nectarine", "orange", "papaya", "quince", "raspberry", "strawberry", "tangerine", "ugli-fruit", "watermelon",
                        "apricot", "blackberry", "blueberry", "cantaloupe", "cranberry", "currant", "durian", "elderflower", "gooseberry", "grapefruit",
                        "guava", "jackfruit", "kumquat", "lime", "loganberry", "lychee", "mandarin", "mulberry", "olive", "passionfruit",
                        "peach", "pear", "persimmon", "plum", "pomegranate", "pomelo", "prune", "rhubarb", "starfruit", "tamarind",
                        "ant", "bear", "cat", "dog", "elephant", "fox", "giraffe", "horse", "iguana", "jaguar",
                        "kangaroo", "lion", "monkey", "newt", "owl", "penguin", "quail", "rabbit", "snake", "tiger",
                        "turtle", "urchin", "vulture", "walrus", "x-ray-fish", "yak", "zebra", "potato-cakes", "carrot", "broccoli",
                        "asparagus", "cabbage", "celery", "corn", "cucumber", "eggplant", "garlic", "kale", "lettuce", "mushroom",
                        "onion", "pepper", "pumpkin", "radish", "spinach", "tomato", "turnip", "zucchini", "avocado", "almond"
                    ],
                    "\"",
                    "\"apple\", \"banana\", \"cherry\", \"date\", \"elderberry\", \"fig\", \"grape\", \"honeydew\", \"kiwi\", \"lemon\", \"mango\", \"nectarine\", \"orange\", \"papaya\", \"quince\", \"raspberry\", \"strawberry\", \"tangerine\", \"ugli-fruit\", \"watermelon\", \"apricot\", \"blackberry\", \"blueberry\", \"cantaloupe\", \"cranberry\", \"currant\", \"durian\", \"elderflower\", \"gooseberry\", \"grapefruit\", \"guava\", \"jackfruit\", \"kumquat\", \"lime\", \"loganberry\", \"lychee\", \"mandarin\", \"mulberry\", \"olive\", \"passionfruit\", \"peach\", \"pear\", \"persimmon\", \"plum\", \"pomegranate\", \"pomelo\", \"prune\", \"rhubarb\", \"starfruit\", \"tamarind\", \"ant\", \"bear\", \"cat\", \"dog\", \"elephant\", \"fox\", \"giraffe\", \"horse\", \"iguana\", \"jaguar\", \"kangaroo\", \"lion\", \"monkey\", \"newt\", \"owl\", \"penguin\", \"quail\", \"rabbit\", \"snake\", \"tiger\", \"turtle\", \"urchin\", \"vulture\", \"walrus\", \"x-ray-fish\", \"yak\", \"zebra\", \"potato-cakes\", \"carrot\", \"broccoli\", \"asparagus\", \"cabbage\", \"celery\", \"corn\", \"cucumber\", \"eggplant\", \"garlic\", \"kale\", \"lettuce\", \"mushroom\", \"onion\", \"pepper\", \"pumpkin\", \"radish\", \"spinach\", \"tomato\", \"turnip\", \"zucchini\", \"avocado\", \"almond\""
                }
            };
    }
}
