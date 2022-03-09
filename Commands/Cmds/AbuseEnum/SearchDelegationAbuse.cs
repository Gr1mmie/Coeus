using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class SearchDelegation : Command
    {
        private bool Constrained { get; set; }
        private bool UnConstrained { get; set; }
        private bool RBCD { get; set; }
        public override string CommandName => "DelegateSearch";

        public override string CommandDesc => "Search for machines succeptable to delegation attacks domain wide";
        public override string CommandUsage => "[*] Usage: DelegateSearch";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            UI.FilterSet(DS.searcher, "(&(objectCategory=user)(userAccountControl:1.2.840.113556.1.4.803:=524288))", DS.scope);

            if (DS.searcher.FindAll() != null) {
                outData.AppendLine("[*] Located machines trusted for delegation (uncontrained delegation)");
                UI.SearchBanner(DS.searcher.Filter);
                foreach (SearchResult acc in DS.searcher.FindAll()) { outData.AppendLine($"{acc.Properties["CN"][0],-25}: {acc.Path}"); }
            }

            outData.AppendLine();

            UI.FilterSet(DS.searcher, "(userAccountControl:1.2.840.113556.1.4.803:=1048576)", DS.scope);

            if (DS.searcher.FindAll() != null) {
                outData.AppendLine("[*] Locateing machines not trusted for delegation (constrained delegation) ");
                UI.SearchBanner(DS.searcher.Filter);
                foreach (SearchResult acc in DS.searcher.FindAll()) { outData.AppendLine($"{acc.Properties["CN"][0],-25}: {acc.Path}"); }
            }

            // RCBD -> https://github.com/ZeroDayLab/PowerSploit/blob/master/Recon/PowerView.ps1#L5435

            return outData.ToString();
        }
    }
}
