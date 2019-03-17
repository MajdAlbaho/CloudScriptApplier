using CloudScriptApplier.Console.Unity;
using CloudScriptApplier.Db;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

            kernal.Get<IStarter>().Initialize();
        }
    }
}
