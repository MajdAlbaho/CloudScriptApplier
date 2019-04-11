using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ServerDb;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CloudScriptApplier.Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


        }
    }

    public class BootStrap : NinjectModule
    {
        public override void Load()
        {
            Bind<IInternetConnectionManager>().To<InternetConnectionManager>();
            Bind<ISecurityManager>().To<SecurityManager>();
            Bind<IScriptManager>().To<ScriptManager>();
            Bind<IConnectionStringManager>().To<ConnectionStringManager>();

            var serverDbManagerInstance = Kernel.Get<ServerDbManager>();
            serverDbManagerInstance.Initialize("172.16.11.27", "CloudScriptApplier",
                "edward", "12345");
            Bind<IServerDbManager>().ToConstant(serverDbManagerInstance);
        }
    }
}
