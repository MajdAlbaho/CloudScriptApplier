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

            NetworkCredential theNetworkCredential = new NetworkCredential(@"Temo", "P@ssw0rd");
            CredentialCache theNetCache = new CredentialCache();
            theNetCache.Add(new Uri(@"\\82.137.255.183\Fofo"), "Basic", theNetworkCredential);

            var files = Directory.GetFiles(@"\\172.16.11.23\Fofo");

            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            kernal.Get<IStarter>().Initialize();
        }
    }
}
