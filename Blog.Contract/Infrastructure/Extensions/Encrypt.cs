using System.Security.Cryptography;
using System.Text;

namespace Blog.Contract.Infrastructure.Extensions
{
    public class Encrypt
    {
        public static string Md5(string input)
        {
            // 防止出现空字符
            input = string.IsNullOrWhiteSpace(input) ? string.Empty : input;

            byte[] bs = Encoding.UTF8.GetBytes(input);
            StringBuilderExtensions xMBuilder = new StringBuilderExtensions();

            using (MD5 m = MD5.Create())
            {
                foreach (byte item in m.ComputeHash(bs))
                {
                    xMBuilder.AppendFormat("{0:x2}", item);
                }
            }

            return xMBuilder.ToString();
        }

        public static string Md5(string input, string salt)
        {
            return Md5(string.Format("{0}{1}", input, salt));
        }
    }
}
