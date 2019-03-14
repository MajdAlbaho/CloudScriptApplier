using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public class SecurityManager : ISecurityManager
    {
        public string DecryptString(string encrString) {
            byte[] b;
            string decrypted;
            try {
                b = Convert.FromBase64String(encrString);
                decrypted = Encoding.ASCII.GetString(b);
            }
            catch (FormatException) {
                decrypted = "";
            }
            return decrypted;
        }

        public string EnryptString(string strEncrypted) {
            byte[] b = Encoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
