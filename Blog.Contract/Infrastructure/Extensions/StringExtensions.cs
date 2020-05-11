namespace Blog.Contract.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool NoCharacters(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool HasCharacters(this string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
