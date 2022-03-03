using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class InterestingAccounts : Command
    {
        public override string CommandName => "InterestingAccounts";

        public override string CommandDesc => "Returns potentially interesting accounts";

        public override string CommandUsage => "[*] Usage: InterestingAccounts";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string CNs = null;

            foreach (string cn in interestingCNs) { CNs += $"(cn={cn})"; }

            outData.AppendLine($"[*] Locating potentially interesting accounts in the {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, $"(&(samaccounttype=805306368)(|{CNs}))", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult acc in searcher.FindAll()) { outData.AppendLine($"{acc.Properties["CN"][0],-25}: {acc.Path}"); }

            return outData.ToString();
        }
    }
}
