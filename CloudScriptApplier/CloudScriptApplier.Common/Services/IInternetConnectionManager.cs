using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public interface IInternetConnectionManager
    {
        bool IsValidConnection(string site = "www.google.com");
    }
}
