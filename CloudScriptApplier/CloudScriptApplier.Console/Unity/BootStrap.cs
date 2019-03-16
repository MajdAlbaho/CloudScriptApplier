using CloudScriptApplier.Common.Services;
using CloudScriptApplier.Db.ClientDb;
using CloudScriptApplier.Db.ServerDb;
using CloudScriptApplier.MegaCloud;
using Ninject;
using Ninject.Modules;

namespace CloudScriptApplier.Console.Unity
{
    public class BootStrap : NinjectModule
    {
        public override void Load() {
            Bind<IMegaClientManager>().ToConstant(Kernel.Get<MegaClientManager>());
            Bind<IInternetConnectionManager>().To<InternetConnectionManager>();
            Bind<ISecurityManager>().To<SecurityManager>();
            Bind<IScriptManager>().To<ScriptManager>();
            Bind<IConnectionStringManager>().To<ConnectionStringManager>();
            Bind<IStarter>().To<StartServerTarget>();

            var serverDbManagerInstance = Kernel.Get<ServerDbManager>();
            serverDbManagerInstance.Initialize();
            Bind<IServerDbManager>().ToConstant(serverDbManagerInstance);


            var clientDbManagerInstance = Kernel.Get<ClientDbManager>();
            clientDbManagerInstance.Initialize();
            Bind<IClientDbManager>().ToConstant(clientDbManagerInstance);

        }
    }
}
