using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public interface IConnectionStringManager
    {
        string CreateDynamicConnectionString();
        string CreateStaticConnectionString(string serverName, string DbName, string userName, string password);
    }
}
