using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public interface IScriptManager
    {
        string ReadCommands(string scriptFile);
        bool DeleteFile(string scriptPath);
    }
}
