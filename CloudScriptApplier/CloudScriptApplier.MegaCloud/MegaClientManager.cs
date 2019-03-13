using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Web.MegaApiClient;

namespace CloudScriptApplier.MegaCloud
{
    public class MegaClientManager
    {
        private MegaApiClient _client;

        public IMegaApiClient GetInstance()
        {
            return _client ?? (_client = new MegaApiClient());
        }


        private void Login()
        {
            _client.Login("ScriptApplier@gmail.com", "P@ssw0rd@123");
        }

        public void Download(INode file, string path) => GetInstance().DownloadFile(file, path);

        public void DeleteFile(INode file) => GetInstance().Delete(file);

        public IEnumerable<INode> GetFolderFilesByFacilityCode(string facilityCode)
        {
            var nodes = GetInstance().GetNodes();

            if (nodes.FirstOrDefault(node => node.Name == facilityCode) == null)
                GetInstance().CreateFolder(facilityCode, nodes.First(x => x.Type == NodeType.Root));

            INode parentFolder = nodes.First(node => node.Name == facilityCode);

            GetInstance().GetNodes();

            var files = nodes.Where(node => node.ParentId == parentFolder.Id);
            return files.Where(e => e.Name.EndsWith(".txt") || e.Name.EndsWith(".sql")).ToList();
        }
    }
}
