using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudScriptApplier.Db.ServerDb;

namespace CloudScriptApplier.Db.Logger
{
    public class LoggerService : ILoggerService
    {

        public void Log(string message, string dbName, string serverName, string script = null) {
            using (var db = new ServerDbDataContext()) {
                db.Logs.InsertOnSubmit(new Log() {
                    Result = message,
                    Script = script,
                    ServerName = serverName
                });

                db.SubmitChanges();
            }
        }
    }
}
