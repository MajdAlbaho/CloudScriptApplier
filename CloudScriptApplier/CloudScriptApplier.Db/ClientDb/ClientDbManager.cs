using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ServerDb;
using System;
using System.Collections.Generic;
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
            SetConnectionString();
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
                // TODO: Get db name
                _serverDbManager.Log(e.Message, logHistoryType.Error, command, Environment.MachineName, "");
            }
        }

        public List<string> GetDbsCodes() {
            return ExecuteQuery<string>("SELECT name FROM sys.databases")
                    .Where(DbName => DbName.Contains(".")).ToList();
        }

        public void SetConnectionString() {
            Connection.ConnectionString =
                _connectionStringManager.CreateDynamicConnectionString();
        }
    }
}
