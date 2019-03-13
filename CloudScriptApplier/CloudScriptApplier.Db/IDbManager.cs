using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db
{
    internal interface IDbManager
    {
        void RunCommand(string command);
        void CreateConnectionString();
        string GetDbsCodes();
        void LogResult(string result, string scriptName);
        DbManager.DbConnectionState GetConnectionState();
    }
}
