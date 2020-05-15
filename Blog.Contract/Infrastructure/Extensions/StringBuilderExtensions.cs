using System.Text;

namespace Blog.Contract.Infrastructure.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormatIf(this StringBuilder sbuilder, bool predicate, string format, params object[] args)
        {
            if (predicate)
            {
                sbuilder.AppendFormat(format, args);
            }

            return sbuilder;
        }
    }
}
