using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.Logger
{
    public interface ILoggerService
    {
        void Log(string message, string dbName, string serverName, string script = null);
    }
}
