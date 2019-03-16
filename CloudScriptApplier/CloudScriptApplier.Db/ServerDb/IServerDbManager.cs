using CloudScriptApplier.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.ServerDb
{
    public interface IServerDbManager
    {
        bool LogMessage(string Message, logHistoryType logHistoryType, string script, string serverName, string dbName);

        List<Scripts> GetScriptsByDbName(string dbName);

        void RegisterDatabase(string dbName);
        void Delete(Scripts script);
    }

    public enum logHistoryType
    {
        Success,
        Error,
        Information
    }
}
