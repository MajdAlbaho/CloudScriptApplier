using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudScriptApplier.Common;
using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ClientDb;
using CloudScriptApplier.Db.Logger;
using CloudScriptApplier.Db.ServerDb;
using Microsoft.Win32;

namespace CloudScriptApplier.Db
{
    public class DbManager : ClientDbDataContext, IDbManager
    {
        private readonly ISecurityManager _securityManager;
        private readonly IScriptManager _scriptManager;
        private readonly ILoggerService _loggerService;

        public DbManager(ISecurityManager securityManager,
                    IScriptManager scriptManager, ILoggerService loggerService) {
            _securityManager = securityManager;
            _scriptManager = scriptManager;
            _loggerService = loggerService;
        }

        public void Initialize() {
            CreateConnectionString();
            Connection.ConnectionString = ConnectionString;
        }


        public string ConnectionString { get; private set; }
        bool _invalidConnectionString = false;

        public void CreateConnectionString() {
            if (_invalidConnectionString)
                return;

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "connectionString.txt");

            if (File.Exists(path)) {
                var encryptedConnection = File.ReadAllText(path);
                ConnectionString = _securityManager.DecryptString(encryptedConnection);
                return;
            }

            if (ReadFromRegistry()) {
                var con = File.Create(path);

                using (var writer = new StreamWriter(con)) {
                    var encrypted = _securityManager.EnryptString(ConnectionString);
                    writer.Write(encrypted);
                }
            } else {
                _loggerService.Log($"Failed to create connection string at {Environment.MachineName}",
                    "", Environment.MachineName);
            }
        }

        public bool ReadFromRegistry() {
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView)) {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null) {
                    if (instanceKey.GetValueNames().Count() == 1) {
                        string instanceName = instanceKey.GetValueNames().First();
                        ConnectionString = instanceName == "MSSQLSERVER" ?
                                $"Data Source={Environment.MachineName};Initial Catalog=master;User ID=sa;Password=P@ssw0rd" :
                                $"Data Source={Environment.MachineName}\\{instanceName};Initial Catalog=master;User ID=sa;Password=P@ssw0rd";
                        return true;
                    }

                    _invalidConnectionString = true;
                }
            }
            return false;
        }

        public DbConnectionState GetConnectionState() {
            return _invalidConnectionString ? DbConnectionState.Invalid : DbConnectionState.Valid;
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
                _loggerService.Log(e.Message, "", Environment.MachineName, command);
            }
        }

        public List<string> GetDbsCodes() {
            return ExecuteQuery<string>("SELECT name FROM sys.databases")
                    .Where(DbName => DbName.Contains(".")).ToList();
        }

        public enum DbConnectionState
        {
            Valid, Invalid
        }


    }
}
