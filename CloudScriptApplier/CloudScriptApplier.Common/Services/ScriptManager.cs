using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudScriptApplier.MegaCloud;

namespace CloudScriptApplier.Common.Services
{
    public class ScriptManager : IScriptManager
    {
        public string ReadCommands(string scriptFile) {
            return File.ReadAllText(scriptFile);
        }

        public bool DeleteFile(string scriptPath) {
            if (File.Exists(scriptPath)) {
                File.Delete(scriptPath);
                return true;
            }

            return false;
        }
    }
}
