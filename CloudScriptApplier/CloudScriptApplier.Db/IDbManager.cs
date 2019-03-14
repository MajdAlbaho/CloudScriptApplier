using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db
{
    public interface IDbManager
    {
        void ExecuteScripts(string scriptPath);
        void CreateConnectionString();
        List<string> GetDbsCodes();
        void LogResult(string result, string scriptName,string DbName);
        DbManager.DbConnectionState GetConnectionState();
    }
}
