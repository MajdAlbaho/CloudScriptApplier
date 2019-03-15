using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Web.MegaApiClient;

namespace CloudScriptApplier.MegaCloud
{
    public class MegaClientManager : IMegaClientManager
    {
        private MegaApiClient _client;

        private IMegaApiClient GetInstance() {
            if (_client == null)
                _client = new MegaApiClient();

            if (!_client.IsLoggedIn)
                Login();

            return _client;
        }


        private void Login() {
            _client.Login("ScriptApplier@gmail.com", "P@ssw0rd@123");
        }

        public void Download(INode file, string targetPath) {
            GetInstance().DownloadFile(file, targetPath);
            GetInstance().Delete(file);
        }

        public bool DeleteFile(INode file) {
            if (file != null) {
                GetInstance().Delete(file);
                return true;
            }

            return false;
        }

        public IEnumerable<INode> GetFolderFilesByDbName(string facilityCode) {
            var client = GetInstance();
            var nodes = client.GetNodes();

            if (nodes.FirstOrDefault(node => node.Name == facilityCode) == null) {
                client.CreateFolder(facilityCode, nodes.First(x => x.Type == NodeType.Root));
                nodes = client.GetNodes();
            }

            INode parentFolder = nodes.First(node => node.Name == facilityCode);


            var files = nodes.Where(node => node.ParentId == parentFolder.Id);
            return files.Where(e => e.Name.EndsWith(".txt") || e.Name.EndsWith(".sql")).ToList();
        }
    }
}
