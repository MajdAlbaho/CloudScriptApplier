using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Models
{
    public class Scripts
    {
        public Guid Id { get; set; }
        public string ScriptName { get; set; }
        public string ScriptText { get; set; }
        public int DatabaseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserMessage { get; set; }
    }
}
