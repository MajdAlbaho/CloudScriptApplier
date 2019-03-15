using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db;
using CloudScriptApplier.Db.Logger;
using CloudScriptApplier.MegaCloud;
using Ninject;
using Ninject.Modules;

namespace CloudScriptApplier.Console.Unity
{
    public class BootStrap : NinjectModule
    {
        public override void Load() {
            Bind<IMegaClientManager>().ToConstant(new MegaClientManager());
            Bind<IInternetConnectionManager>().To<InternetConnectionManager>();
            Bind<ISecurityManager>().To<SecurityManager>();
            Bind<IScriptManager>().To<ScriptManager>();
            Bind<ILoggerService>().To<LoggerService>();

            var dbManagerInstance = Kernel.Get<DbManager>();
            dbManagerInstance.Initialize();

            Bind<IDbManager>().ToConstant(dbManagerInstance);

        }
    }
}
