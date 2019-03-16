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
    public class Start
    {
        private readonly IInternetConnectionManager _internetConnectionManager;
        private readonly IMegaClientManager _megaClientManager;
        private readonly IClientDbManager _clientDbManager;
        private readonly IServerDbManager _serverDbManager;

        public Start(IInternetConnectionManager internetConnectionManager,
                IMegaClientManager megaClientManager, IClientDbManager clientDbManager,
                IServerDbManager serverDbManager) {
            _internetConnectionManager = internetConnectionManager;
            _megaClientManager = megaClientManager;
            _clientDbManager = clientDbManager;
            _serverDbManager = serverDbManager;
        }

        public void Initialize() {
            try {
                if (_internetConnectionManager.IsValidConnection()) {
                    var dbNames = _clientDbManager.GetDbsCodes();
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
                // TODO: Get command and Db name
                _serverDbManager.Log(e.Message, logHistoryType.Error, "", Environment.MachineName, "");
            }
        }

    }
}