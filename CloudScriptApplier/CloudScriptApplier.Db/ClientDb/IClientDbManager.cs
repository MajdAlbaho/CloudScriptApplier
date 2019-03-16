using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.ClientDb
{
    public interface IClientDbManager
    {
        void ExecuteScripts(string scriptPath);
        List<string> GetDbsCodes();
    }
}
