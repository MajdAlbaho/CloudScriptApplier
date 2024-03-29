﻿using CloudScriptApplier.Common;
using CloudScriptApplier.Common.Models;
using CloudScriptApplier.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.ServerDb
{
    public class ServerDbManager : ServerDbDataContext, IServerDbManager
    {
        private readonly IConnectionStringManager _connectionStringManager;

        public ServerDbManager(IConnectionStringManager connectionStringManager)
        {
            _connectionStringManager = connectionStringManager;
        }

        public void Initialize(string serverName, string dbName, string userName, string password)
        {
            Connection.ConnectionString =
                _connectionStringManager.CreateStaticConnectionString(serverName,
                    dbName, userName, password);
        }

        public bool LogMessage(string Message, logHistoryType logHistoryType, string script, string serverName, string dbName)
        {
            try
            {
                LogHistories.InsertOnSubmit(new LogHistory()
                {
                    LogMessage = Message,
                    LogHistoryTypeId = (int)logHistoryType,
                    Script = script,
                    ServerName = serverName,
                    DbName = dbName
                });

                SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                // TODO: Log error to other place
                return false;
            }
        }

        public List<Scripts> GetScriptsByDbName(string dbName)
        {
            var Db = Databases.FirstOrDefault(db => db.DatabaseName == dbName);

            if (Db != null)
            {
                return Scripts.Where(e => e.DatabaseId == Db.Id).Select(e => new Scripts()
                {
                    Id = e.Id,
                    DatabaseId = e.DatabaseId,
                    CreatedDate = e.CreatedDate,
                    ScriptText = e.ScriptText,
                    ScriptName = e.ScriptName,
                    UserMessage = e.UserMessage
                }).OrderBy(s => s.CreatedDate).ToList();
            }

            return null;
        }

        public void RegisterDatabase(string dbName)
        {
            if (!Databases.Any(e => e.DatabaseName == dbName))
            {
                Databases.InsertOnSubmit(new Database()
                {
                    DatabaseName = dbName,
                    DatabaseCode = dbName,
                    DatabaseTypeId = dbName.Contains("HIS") ? (int)DatabaseTypes.HIS
                                            : dbName.Contains("PSIS") ? (int)DatabaseTypes.PSIS
                                            : (int)DatabaseTypes.Unknown
                });

                SubmitChanges();
            }
        }

        public List<GetRegisteredDatabase> GetRegisteredDBS(string dbName = null)
        {
            if (dbName == null)
                return GetRegisteredDatabases.ToList();

            return GetRegisteredDatabases
                        .Where(item => item.DatabaseName.Contains(dbName)).ToList();
        }

        public void Delete(Scripts script)
        {
            try
            {
                var dbItem = Scripts.FirstOrDefault(e => e.Id == script.Id);
                if (dbItem == null)
                    throw new NullReferenceException($"Couldn't find any script with code {script.Id}");


                Scripts.DeleteOnSubmit(dbItem);
                SubmitChanges();
            }
            catch (Exception e)
            {
                LogMessage(e.Message, logHistoryType.Error, "", Environment.MachineName, "");
            }
        }

        public List<LogHistory> GetLogsHistory()
        {
            var Items = LogHistories.ToList();
            return Items;
        }
    }
}
