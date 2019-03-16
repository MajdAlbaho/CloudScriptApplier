using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.ServerDb
{
    public interface IServerDbManager
    {
        bool Log(string logMessage, logHistoryType logHistoryType, string script, string serverName, string dbName);
    }

    public enum logHistoryType
    {
        Success,
        Error,
        Information
    }
}
