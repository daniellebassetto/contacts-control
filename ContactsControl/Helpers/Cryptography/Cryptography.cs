using System.Security.Cryptography;
using System.Text;

namespace ContactsControl.Helpers
{
    public static class Cryptography
    {
        public static string GenerateHash(this string value)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(value);

            array = hash.ComputeHash(array);

            var strhexa = new StringBuilder();

            foreach(var item in array)
            {
                strhexa.Append(item.ToString("x2"));
            }

            return strhexa.ToString();
        }
    }
}