using System;

namespace Blog.Contract.Infrastructure
{
    /// <summary>
    /// 数据库逻辑
    /// </summary>
    public sealed class DbBoolean
    {
        [Obsolete]
        public const string TrueString = "1";

        [Obsolete]
        public const int True = 1;

        [Obsolete]
        public const string FalseString = "0";

        [Obsolete]
        public const int False = 0;
    }
}
