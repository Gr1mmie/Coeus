using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class SearchRoast : Command
    {
        private bool ASREP { get; set; }
        private bool Kerber { get; set; }
        public override string CommandName => "RoastHunter";

        public override string CommandDesc => "Search for machines succeptable to roasting attacks domain wide";
        public override string CommandUsage => "[*] Usage: RoastHunter";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            UI.FilterSet(DS.searcher, "(&(objectCategory=user)(!(samAccountName=krbtgt)(servicePrincipalName=*)))", DS.scope);

            if (DS.searcher.FindAll() != null) {
                outData.AppendLine("[+] Locating Kerberoastable users: ");
                UI.SearchBanner(DS.searcher.Filter);
                foreach (SearchResult acc in DS.searcher.FindAll()) { outData.AppendLine($"{acc.Properties["CN"][0],-25}: {acc.Path}"); }
            }

            outData.AppendLine();

            UI.FilterSet(DS.searcher, "(&(objectCategory=person)(objectClass=user)(userAccountControl:1.2.840.113556.1.4.803:=4194304))", DS.scope);

            if (DS.searcher.FindAll() != null) {
                outData.AppendLine("[+] Locating AS-REPRoastable users ");
                UI.SearchBanner(DS.searcher.Filter);
                foreach (SearchResult acc in DS.searcher.FindAll()) { outData.AppendLine($"{acc.Properties["CN"][0],-25}: {acc.Path}"); }
            }

            return outData.ToString();
        }
    }
}
