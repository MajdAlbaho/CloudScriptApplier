using CloudScriptApplier.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.ServerDb
{
    public class ServerDbManager : ServerDbDataContext, IServerDbManager
    {
        private readonly IConnectionStringManager _connectionStringManager;

        public ServerDbManager(IConnectionStringManager connectionStringManager) {
            _connectionStringManager = connectionStringManager;
        }

        public void Initialize() {
            this.Connection.ConnectionString = _connectionStringManager.CreateStaticConnectionString(
                "Home-PC", "ScriptApplierLog", "sa", "P@ssw0rd@123");
        }

        bool IServerDbManager.Log(string logMessage, logHistoryType logHistoryType, string script, string serverName, string dbName) {
            try {
                LogHistories.InsertOnSubmit(new LogHistory() {
                    LogMessage = logMessage,
                    LogHistoryTypeId = (int)logHistoryType,
                    Script = script,
                    ServerName = serverName,
                    DbName = dbName
                });

                SubmitChanges();
                return true;
            }
            catch (Exception e) {
                // TODO: Log error to other place
                return false;
            }
        }
    }
}
