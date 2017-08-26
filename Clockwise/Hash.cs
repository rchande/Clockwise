using System;
using System.Security.Cryptography;
using System.Text;

namespace Clockwise
{
    internal static class Hash
    {
        /// <summary>
        /// Generates a token which is repeatable from a given source string.
        /// </summary>
        public static string ToToken(this string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var inputBytes = Encoding.ASCII.GetBytes(value);

            byte[] hash;
            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(inputBytes);
            }

            return Convert.ToBase64String(hash);
        }
    }
}
