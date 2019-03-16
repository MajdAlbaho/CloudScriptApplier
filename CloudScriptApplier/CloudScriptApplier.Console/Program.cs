using CloudScriptApplier.Console.Unity;
using CloudScriptApplier.Db;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Console
{
    class Program
    {
        static void Main(string[] args) {
            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            //kernal.Get<StartMegaTarget>().Initialize();
            kernal.Get<StartServerTarget>().Initialize();
        }
    }
}
