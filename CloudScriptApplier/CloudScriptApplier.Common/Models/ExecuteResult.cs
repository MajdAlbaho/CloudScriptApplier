using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Models
{
    public class ExecuteResult
    {
        public ExecuteResult(string scriptName, bool success,
            string userMessage) {
            ScriptName = scriptName;
            Success = success;
            UserMessage = userMessage;
        }

        public string ScriptName { get; set; }
        public bool Success { get; set; }
        public string UserMessage { get; set; }
    }
}
