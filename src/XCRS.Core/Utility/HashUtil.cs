using System.Security.Cryptography;
using System.Text;

namespace XCRS.Core.Utility
{
    public static class HashUtil
    {
        public static string GetHashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("x2"));
            }

            // return hexadecimal string
            return returnValue.ToString();
        }
    }
}
