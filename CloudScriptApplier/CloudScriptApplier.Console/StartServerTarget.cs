using CloudScriptApplier.Common;
using CloudScriptApplier.Common.Models;
using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ClientDb;
using CloudScriptApplier.Db.ServerDb;
using CloudScriptApplier.MegaCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Console
{
    public class StartServerTarget : IStarter
    {
        private readonly IInternetConnectionManager _internetConnectionManager;
        private readonly IMegaClientManager _megaClientManager;
        private readonly IClientDbManager _clientDbManager;
        private readonly IServerDbManager _serverDbManager;
        private readonly IConnectionStringManager _connectionStringManager;

        public StartServerTarget(IInternetConnectionManager internetConnectionManager,
                IMegaClientManager megaClientManager, IClientDbManager clientDbManager,
                IServerDbManager serverDbManager, IConnectionStringManager connectionStringManager) {
            _internetConnectionManager = internetConnectionManager;
            _megaClientManager = megaClientManager;
            _clientDbManager = clientDbManager;
            _serverDbManager = serverDbManager;
            _connectionStringManager = connectionStringManager;
        }

        public void Initialize() {
            try {
                if (_internetConnectionManager.IsValidConnection()) {
                    string dbName = _clientDbManager.GetCurrentDbName();

                    // Insert db infromation on databases table if doesn't exist
                    _serverDbManager.RegisterDatabase(dbName);

                    // Get scripts from database ordered by created date
                    List<Scripts> scripts = _serverDbManager.GetScriptsByDbName(dbName);

                    var result = _clientDbManager.ExecuteScripts(scripts);

                    foreach (var item in result) {
                        System.Console.WriteLine(item.ScriptName + " : " + item.UserMessage);
                    }
                }
            }
            catch (Exception e) {
                _serverDbManager.LogMessage(e.Message, logHistoryType.Error, "No script data",
                    Environment.MachineName,
                    _clientDbManager.GetCurrentDbName());
            }
        }
    }
}
