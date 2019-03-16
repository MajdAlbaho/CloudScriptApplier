using CloudScriptApplier.Common;
using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ClientDb;
using CloudScriptApplier.Db.ServerDb;
using CloudScriptApplier.MegaCloud;
using System;
using System.IO;
using System.Linq;

namespace CloudScriptApplier.Console
{
    public class StartMegaTarget : IStarter
    {
        private readonly IInternetConnectionManager _internetConnectionManager;
        private readonly IMegaClientManager _megaClientManager;
        private readonly IClientDbManager _clientDbManager;
        private readonly IServerDbManager _serverDbManager;
        private readonly IConnectionStringManager _connectionStringManager;

        public StartMegaTarget(IInternetConnectionManager internetConnectionManager,
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
                    var dbNames = _clientDbManager.GetDbsNames();

                    foreach (var dbName in dbNames) {
                        var cloudFiles = _megaClientManager.GetFolderFilesByDbName(dbName).ToList();
                        foreach (var cloudFile in cloudFiles) {

                            var directory = Directory.CreateDirectory(Path.Combine(Global.TargetPath, dbName));
                            _megaClientManager.Download(cloudFile, Path.Combine(directory.FullName, cloudFile.Name));
                        }

                        if (cloudFiles.Any()) {
                            _clientDbManager.ExecuteScripts(Path.Combine(Global.TargetPath, dbName));
                        }
                    }
                }
            }
            catch (Exception e) {
                _serverDbManager.LogMessage(e.Message, logHistoryType.Error, "No data for script",
                    Environment.MachineName, _clientDbManager.GetCurrentDbName());
            }
        }

    }
}