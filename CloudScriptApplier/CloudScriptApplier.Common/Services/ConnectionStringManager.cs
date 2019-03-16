using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public class ConnectionStringManager : IConnectionStringManager
    {
        private readonly ISecurityManager _securityManager;

        public ConnectionStringManager(ISecurityManager securityManager) {
            _securityManager = securityManager;
        }

        public string ConnectionString { get; private set; }
        bool _invalidConnectionString = false;


        public string CreateDynamicConnectionString() {
            if (_invalidConnectionString)
                throw new Exception("More than one instance found, Could not create connection string");

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "connectionString.txt");

            if (File.Exists(path)) {
                var encryptedConnection = File.ReadAllText(path);
                ConnectionString = _securityManager.DecryptString(encryptedConnection);
            }

            if (ReadFromRegistry()) {
                var con = File.Create(path);

                using (var writer = new StreamWriter(con)) {
                    var encrypted = _securityManager.EnryptString(ConnectionString);
                    writer.Write(encrypted);
                }
            }
            else {
                throw new Exception($"Failed to create connection string at {Environment.MachineName}");
            }

            return ConnectionString;
        }

        private bool ReadFromRegistry() {
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView)) {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null) {
                    if (instanceKey.GetValueNames().Count() == 1) {
                        string instanceName = instanceKey.GetValueNames().First();
                        ConnectionString = instanceName == "MSSQLSERVER" ?
                                $"Data Source={Environment.MachineName};Initial Catalog=master;User ID=sa;Password=P@ssw0rd@123" :
                                $"Data Source={Environment.MachineName}\\{instanceName};Initial Catalog=master;User ID=sa;Password=P@ssw0rd@123";
                        return true;
                    }

                    _invalidConnectionString = true;
                }
            }
            return false;
        }

        public string CreateStaticConnectionString(string serverName, string DbName, string userName, string password) {
            return $"Data Source={serverName};Initial Catalog={DbName};User ID={userName};Password={password}";
        }
    }
}
