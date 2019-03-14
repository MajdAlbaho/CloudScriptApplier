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
using CloudScriptApplier.Db.ServerDb;
using Microsoft.Win32;

namespace CloudScriptApplier.Db {
    public class DbManager : ClientDbDataContext, IDbManager {
        private readonly ISecurityManager _securityManager;
        private readonly IScriptManager _scriptManager;

        public DbManager(ISecurityManager securityManager,
                    IScriptManager scriptManager)
        {
            _securityManager = securityManager;
            _scriptManager = scriptManager;
        }

        public void Initialize()
        {
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
            } else {
                if (ReadFromRegistry()) {
                    var con = File.Create(path);

                    using (var writer = new StreamWriter(con)) {
                        var encrypted = _securityManager.EnryptString(ConnectionString);
                        writer.Write(encrypted);
                    }
                } else {
                    LogResult($"Failed to create connection string at {Environment.MachineName}", "", "");
                }
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

        public void ExecuteScripts(string scriptsPath)
        {
            var files = Directory.GetFiles(scriptsPath);
            foreach (var file in files)
            {
                ((DataContext)this).ExecuteCommand(_scriptManager.ReadCommands(file));
            }
        }

        public List<string> GetDbsCodes() {
            return ExecuteQuery<string>("SELECT name FROM sys.databases")
                    .Where(DbName => DbName.Contains(".")).ToList();
        }

        public void LogResult(string result, string scriptName = null,string dbName = null) {
            using (var db = new ServerDbDataContext()) {
                db.Logs.InsertOnSubmit(new Log() {
                    DbName = dbName,
                    Result = result,
                    ScriptName = scriptName,
                    ServerName = Environment.MachineName
                });

                db.SubmitChanges();
            }
        }

        public enum DbConnectionState {
            Valid, Invalid
        }


    }
}
