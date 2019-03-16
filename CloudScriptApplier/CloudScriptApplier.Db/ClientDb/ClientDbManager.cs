using CloudScriptApplier.Common.Models;
using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ServerDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CloudScriptApplier.Db.ClientDb
{
    public class ClientDbManager : ClientDbDataContext, IClientDbManager
    {
        private readonly ISecurityManager _securityManager;
        private readonly IScriptManager _scriptManager;
        private readonly IServerDbManager _serverDbManager;
        private readonly IConnectionStringManager _connectionStringManager;

        public ClientDbManager(ISecurityManager securityManager,
                    IScriptManager scriptManager, IServerDbManager serverDbManager,
                    IConnectionStringManager connectionStringManager) {
            _securityManager = securityManager;
            _scriptManager = scriptManager;
            _serverDbManager = serverDbManager;
            _connectionStringManager = connectionStringManager;
        }

        public void Initialize() {
            //Connection.ConnectionString =
            //    _connectionStringManager.CreateDynamicConnectionString();

            Connection.ConnectionString =
                _connectionStringManager.CreateStaticConnectionString("Home-PC", "HIS.Dev", "sa", "P@ssw0rd@123");
        }

        public void ExecuteScripts(List<Scripts> scripts) {
            foreach (var script in scripts) {
                Execute(script.ScriptText);
                _serverDbManager.Delete(script);
            }
        }

        public void ExecuteScripts(string scriptsPath) {
            var files = Directory.GetFiles(scriptsPath);

            foreach (var file in files) {
                Execute(_scriptManager.ReadCommands(file));
                _scriptManager.DeleteFile(file);
            }
        }

        private void Execute(string command) {
            try {
                ExecuteCommand(command);
            }
            catch (Exception e) {
                _serverDbManager.LogMessage(e.Message, logHistoryType.Error, command,
                    Environment.MachineName,
                    GetCurrentDbName());
            }
        }

        public List<string> GetDbsNames() {
            return ExecuteQuery<string>("SELECT name FROM sys.databases")
                    .Where(DbName => DbName.Contains(".")).ToList();
        }

        public string GetCurrentDbName() {
            SqlConnectionStringBuilder connection =
                new SqlConnectionStringBuilder(Connection.ConnectionString);

            return connection.InitialCatalog;
        }
    }
}
