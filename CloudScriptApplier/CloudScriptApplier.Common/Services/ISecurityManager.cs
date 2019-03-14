using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public interface ISecurityManager
    {
        string DecryptString(string encrString);
        string EnryptString(string strEncrypted);
    }
}
