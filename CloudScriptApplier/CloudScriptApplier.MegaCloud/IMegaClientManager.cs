using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CG.Web.MegaApiClient;

namespace CloudScriptApplier.MegaCloud
{
    public interface IMegaClientManager
    {
        void Download(INode file, string targetPath);
        bool DeleteFile(INode file);
        IEnumerable<INode> GetFolderFilesByDbName(string facilityCode);
    }
}
