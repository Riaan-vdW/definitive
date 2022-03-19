namespace Share;

/// <summary>
/// Split Camel Case String Extension
/// </summary>
public static class SplitCamelCaseStringExtension
{
    /// <summary>
    /// Split Camel case string into words
    /// </summary>
    /// <param name="input">Input string</param>
    /// <returns>Split string</returns>
    public static string ToSplitCamelCase(this string input)
    {
        if (input.Length > 0)
        {
            var result = new List<char>();
            var array = input.ToCharArray();
            var uppercaseCount = array.Count(w => char.IsUpper(w));

            if (array.Length != uppercaseCount)
            {
                foreach (var item in array)
                {
                    if (uppercaseCount == 0 && result.Count == 0)
                        result.Add(char.ToUpper(item));
                    else
                    {
                        if (char.IsUpper(item))
                            result.Add(' ');

                        result.Add(item);
                    }
                }

                return new string(result.ToArray()).Trim();
            }
        }

        return input;
    }
}