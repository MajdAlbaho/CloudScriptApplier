using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudScriptApplier.Common;
using CloudScriptApplier.Db.ClientDb;
using CloudScriptApplier.Db.ServerDb;
using Microsoft.Win32;

namespace CloudScriptApplier.Db
{
    public class DbManager : ClientDbDataContext, IDbManager
    {
        public DbManager()
        {
            CreateConnectionString();
            this.Connection.ConnectionString = connectionString;
        }
        public string connectionString { get; private set; }
        bool invalidConnectionString = false;

        public void CreateConnectionString()
        {
            if (invalidConnectionString)
                return;

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "connectionString.txt");

            if (File.Exists(path))
            {
                var encryptedConnection = File.ReadAllText(path);
                connectionString = SecurityManager.DecryptString(encryptedConnection);
                return;
            }
            else
            {
                if (ReadFromRegistry())
                {
                    var con = File.Create(path);

                    using (var writer = new StreamWriter(con))
                    {
                        var encrypted = SecurityManager.EnryptString(connectionString);
                        writer.Write(encrypted);
                    }
                }
                else
                {
                    LogResult($"Failed to create connection string at {Environment.MachineName}", "");
                }
            }
        }

        public bool ReadFromRegistry()
        {
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    if (instanceKey.GetValueNames().Count() == 1)
                    {
                        string instanceName = instanceKey.GetValueNames().First();
                        if (instanceName == "MSSQLSERVER")
                            connectionString = $"Data Source={Environment.MachineName};Initial Catalog=master;User ID=sa;Password=_SARC#SQL";
                        else
                            connectionString = $"Data Source={Environment.MachineName}\\{instanceName};Initial Catalog=master;User ID=sa;Password=_SARC#SQL";
                        return true;
                    }
                    else
                        invalidConnectionString = true;
                }
            }
            return false;
        }

        public DbConnectionState GetConnectionState()
        {
            return invalidConnectionString ? DbConnectionState.Invalid : DbConnectionState.Valid;
        }

        public void RunCommand(string scriptFile)
        {
            ExecuteCommand(scriptFile);
        }

        public string GetDbsCodes()
        {
            var items = ExecuteQuery<string>("SELECT name FROM sys.databases").ToList();
            StringBuilder result = new StringBuilder();
            foreach (var item in items)
            {
                if (item.Contains("."))
                {
                    result.Append(item);
                    result.Append("-");
                }
            }
            return result.Remove(result.Length - 1, 1).ToString();
        }

        public void LogResult(string result, string scriptName)
        {
            using (var db = new ServerDbDataContext())
            {
                db.Logs.InsertOnSubmit(new Log()
                {
                    DbCode = GetDbsCodes(),
                    Result = result,
                    ScriptName = scriptName,
                    ServerName = Environment.MachineName
                });

                db.SubmitChanges();
            }
        }

        public enum DbConnectionState
        {
            Valid, Invalid
        }


    }
}
