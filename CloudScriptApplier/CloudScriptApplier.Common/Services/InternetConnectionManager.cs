using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CloudScriptApplier.Common.Services
{
    public class InternetConnectionManager : IInternetConnectionManager
    {
        public bool IsValidConnection(string site = "www.google.com") {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            return socket.BeginConnect(site, 80, null, null)
                .AsyncWaitHandle.WaitOne(5000, true);
        }
    }
}
