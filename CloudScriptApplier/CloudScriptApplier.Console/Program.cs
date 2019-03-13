using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CloudScriptApplier.Db;

namespace CloudScriptApplier.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Check For Internet
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IAsyncResult result = socket.BeginConnect("www.google.com", 80, null, null);
                //5 sec timeout
                bool success = result.AsyncWaitHandle.WaitOne(5000, true);
                if (!success)
                {
                    throw new ApplicationException("Failed to connect server.");
                }
            }
            finally
            {
                socket.Close();
            }
        }


    }
}
