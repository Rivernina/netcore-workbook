using System.Linq;

namespace StringUtilities
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            var chars = value.Take(length).ToArray();
            // convert last 3 chars to "..." if we can and it makes since
            if (value.Length > chars.Length && chars.Length > 3)
            {
                chars[chars.Length - 1] = '.';
                chars[chars.Length - 2] = '.';
                chars[chars.Length - 3] = '.';
            }
            var result = new string(chars);
            return result;
        }
    }
}
