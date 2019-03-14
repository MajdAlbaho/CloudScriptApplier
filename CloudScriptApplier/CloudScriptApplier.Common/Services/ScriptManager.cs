using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public class ScriptManager : IScriptManager
    {
        public string ReadCommands(string scriptFile)
        {
            return File.ReadAllText(scriptFile);
        }
    }
}
