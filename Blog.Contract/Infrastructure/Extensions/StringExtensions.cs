using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Contract.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// DES加密
        /// </summary>
        public static string DESEncrypt(this string input)
        {
            using (DES des = DES.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes("2020/05/05");
                byte[] buffer = Encoding.UTF8.GetBytes(input);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, key), CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        public static string DESDecrypt(this string input)
        {
            using (DES des = DES.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes("2020/05/05");
                byte[] buffer = buffer = Convert.FromBase64String(input);

                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, key), CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// 不存在有效空白字符
        /// </summary>
        public static bool NoCharacters(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// 存在有效字符
        /// </summary>
        public static bool HasCharacters(this string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
