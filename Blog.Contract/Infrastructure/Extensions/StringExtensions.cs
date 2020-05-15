using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Contract.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        public static string MD5Encrypt(this string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBuffer = Encoding.UTF8.GetBytes(input);
                byte[] compuBuffer = md5.ComputeHash(inputBuffer);

                StringBuilder xHexBuilder = new StringBuilder();
                compuBuffer.Each(b => xHexBuilder.AppendFormat("{0:x2}", b));

                return xHexBuilder.ToString();
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        public static string MD5Encrypt(this string input, string salt)
        {
            return MD5Encrypt(string.Format("{0}{1}", MD5Encrypt(input), salt));
        }

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
