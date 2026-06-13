# The Refactor changes
## Early exit
**Change:** Added an exit guard at the start of the method.
**Why?:** Exit early so we don't waste any compute on reducant work. 
The original could break if there was no item at the in the first spot of the array, it could also break if the array was null. 
This way we are protected against both of those cases.

## Spelling
**Change:** Sepatated => Separated 
**Why?:** We are all human and make mistakes. Its better to have correct spelling so that it is easier to understand and use.

## Method name
**Change:** ToList => String
**Why?:** The method is returning a string, not a list. A List would infer we are returning a `List<string>` or similar.

## String Construction
**Change:** From string builder to string.join.
**Why?:** String builder can be both performant and readable, but in this case string.join is more concise and easier to read and simplifies the whole implentation into one line. 

## Magic Strings
**Change:** Added a constant for the separator string.
**Why?:** Improved readability and maintainability. If we need to change the separator in the future, we only have to change it in one place.

# Benchmarks
The results below show the performance of the original and refactored methods. 
The refactored method is about 3x faster than the original method and uses about a 30% less memory. 
Whilst that isn't a huge improvement, it is still significant and can make a difference in performance when the method is called frequently or with large arrays.

| Method   | items          | quote | expected            | Mean     | Error     | StdDev    | Gen0      | Gen1      | Gen2     | Allocated |
|--------- |--------------- |------ |-------------------- |---------:|----------:|----------:|----------:|----------:|---------:|----------:|
| Original | String[100000] | "     | "i(...)9" [1388888] | 9.602 ms | 0.1753 ms | 0.2153 ms | 1453.1250 | 1156.2500 | 468.7500 |  10.58 MB |
| Refactor | String[100000] | "     | "i(...)9" [1388888] | 3.672 ms | 0.0574 ms | 0.0638 ms |  726.5625 |  156.2500 | 156.2500 |   7.23 MB |

*Input data is 100,000 items*

# Potential Improvements
Some changes were harder to justify without making assumptions with where it would be used.

## Sanitise input items
Quotes inside items of the array could cause issues with the current implementation. Without knowing exactly where the function is going to be used I can't suggest we escape the quote character or not.
If it is intended to be used with sql... we should definiently escape the quotes to prevent sql injection.
Anything could be a quote right now (eg. ??, ;, //), so its hard to escape every scenario without knowing the context of the function.

## Limit the quote character
The quote character should be limited to subset of characters/strings eg. ' or ". It would make it safer and prevent potential issues with the output string.

## Further Optimisations
I believe we could optimise the function further by stripping out the IEnumerable creation. It would both be faster and more memory efficient.
The current refactor I believe is more readable and easier to understand, thus easier to maintain.

*Optimised version*
```csharp
public static string ToCommaSeparatedList(string[] items, string quote)
{
    if (items == null || items.Length == 0)
        return string.Empty;


    return $"{quote}{string.Join($"{quote}, {quote}", items)}{quote}";
}
```

Below is the benchmark results for the further optimised version with the comparison of the original and refactor. 
Again, we can see a significant improvement in compute time and memory usage compared to the original method, and a decent improvement compared to the refactored method.

| Method           | items          | quote | expected            | Mean     | Error     | StdDev    | Gen0      | Gen1      | Gen2     | Allocated |
|----------------- |--------------- |------ |-------------------- |---------:|----------:|----------:|----------:|----------:|---------:|----------:|
| Original         | String[100000] | "     | "i(...)9" [1388888] | 9.942 ms | 0.1761 ms | 0.1647 ms | 1453.1250 | 1156.2500 | 468.7500 |  10.58 MB |
| Refactor         | String[100000] | "     | "i(...)9" [1388888] | 3.598 ms | 0.0712 ms | 0.1190 ms |  726.5625 |  156.2500 | 156.2500 |   7.23 MB |
| FurtherOptimised | String[100000] | "     | "i(...)9" [1388888] | 1.708 ms | 0.0341 ms | 0.0921 ms |  417.9688 |  417.9688 | 417.9688 |    5.3 MB |

*Input data is 100,000 items*

I understand that at a betting company, sometimes performance optimisations are more important than readability (eg. running sport models in real-time).
Thats why I have added this consideration and yes, there is probably more optimisations that could be made, but I think this is a good balance between readability and performance for most use cases.

