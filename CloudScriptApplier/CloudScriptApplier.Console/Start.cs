using CloudScriptApplier.MegaCloud;
using System;
using System.IO;
using CloudScriptApplier.Common;
using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db;

namespace CloudScriptApplier.Console
{
    public class Start
    {
        private readonly IInternetConnectionManager _internetConnectionManager;
        private readonly IMegaClientManager _megaClientManager;
        private readonly IDbManager _dbManager;

        public Start(IInternetConnectionManager internetConnectionManager,
                IMegaClientManager megaClientManager, IDbManager dbManager) {
            _internetConnectionManager = internetConnectionManager;
            _megaClientManager = megaClientManager;
            _dbManager = dbManager;
        }

        public void Initialize() {
            try {
                if (_internetConnectionManager.IsValidConnection()) {
                    var dbNames = _dbManager.GetDbsCodes();
                    foreach (var dbName in dbNames) {
                        var cloudFiles = _megaClientManager.GetFolderFilesByDbName(dbName);
                        foreach (var cloudFile in cloudFiles) {
                            string scriptPath = Path.Combine(Global.TargetPath, dbName,
                                    cloudFile.Name);

                            if (!File.Exists(scriptPath))
                            {
                                Directory.CreateDirectory(Path.Combine(Global.TargetPath, dbName));
                                _megaClientManager.Download(cloudFile, scriptPath);
                            }
                        }

                        _dbManager.ExecuteScripts(Path.Combine(Global.TargetPath, dbName));

                    }
                }
            }
            catch (Exception e) {
                System.Console.WriteLine(e);
                throw;
            }
        }

    }
}