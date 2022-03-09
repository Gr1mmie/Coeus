using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class LocateExchange : Command
    {
        public override string CommandName => "Exchange";

        public override string CommandDesc => "Return exchange servers";

        public override string CommandUsage => "[*] Usage: Exchange";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Searching for exchange servers");
            UI.FilterSet(DS.searcher, "(objectcategory=msExchExchangeServer)", DS.scope);

            UI.SearchBanner(DS.searcher.Filter);
            foreach (SearchResult svr in DS.searcher.FindAll()) { outData.AppendLine($"{svr.Properties["CN"][0],-25}: {svr.Path}"); }

            return outData.ToString();
        }
    }
}
