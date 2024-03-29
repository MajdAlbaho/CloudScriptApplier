﻿using CloudScriptApplier.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Db.ClientDb
{
    public interface IClientDbManager : IDbManager
    {
        void ExecuteScripts(string scriptPath);
        List<string> GetDbsNames();
        List<ExecuteResult> ExecuteScripts(List<Scripts> scripts);
        string GetCurrentDbName();
    }
}
