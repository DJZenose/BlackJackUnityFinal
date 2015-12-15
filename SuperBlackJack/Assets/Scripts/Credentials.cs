/*************
*Programmers    : Connor McQuade & Brandon Erb
*Professor      : Ed Barsalou
*Date           : 11/8/2015
*
*FILE           : Credentials.cs
**************/

using System.Text;
using System.Security.Cryptography;
namespace Encryption
{
    public class Credentials
    {

        /*
        * Method        :Encrypts
        * Returns       :Int that is the return code
        * Parameters    :Int 
        * Description   :Used for testing/Test Harness....Ignore For now
        */
        public string Encrypt(string userName, string passWord)
        {
            MD5 md = new MD5CryptoServiceProvider();
            string toHash;
            byte[] hash;

            toHash = userName + "+" + passWord;
            hash = md.ComputeHash(Encoding.ASCII.GetBytes(toHash));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();

        }
    }
}
