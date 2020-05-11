using System;

namespace Blog.Contract.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string Localization(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm");
        }
    }
}
