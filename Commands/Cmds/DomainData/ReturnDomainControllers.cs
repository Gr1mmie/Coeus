using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;
namespace Coeus.Commands
{
    public class ReturnDomainControllers : Command
    {
        public override string CommandName => "DomainControllers";

        public override string CommandDesc => "Return all domain controllers";

        public override string CommandUsage => "[*] Usage: DomainControllers";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all domain controllers in the {DomainUtils.CurrentDomain(DS.searcher)} domain");
            UI.FilterSet(DS.searcher, "(&(objectcategory=computer)(useraccountcontrol:1.2.840.113556.1.4.803:=8192))", DS.scope);

            UI.SearchBanner(DS.searcher.Filter);
            foreach (SearchResult dc in DS.searcher.FindAll()) { outData.AppendLine($"{dc.Properties["CN"][0],-25}: {dc.Path}"); }

            return outData.ToString();
        }
    }
}
