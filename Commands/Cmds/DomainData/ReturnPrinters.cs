using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnPrinters : Command {
        public override string CommandName => "Printers";

        public override string CommandDesc => "Fetch printer objects";

        public override string CommandUsage => "[*] Usage: Printers";

        public override string CommandExec(string[] args)
        {
            if (args != null) { throw new CoeusException("[*] Usage: Printers"); }

            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Searching for printers in {DomainUtils.CurrentDomain(DS.searcher)} domain");
            UI.FilterSet(DS.searcher, "(objectCategory=printQueue)", DS.scope);

            UI.SearchBanner(DS.searcher.Filter);
            outData.AppendLine($"[*] Search Filter: {DS.searcher.Filter}\n[*] Search Results:\n");
            foreach (SearchResult printer in DS.searcher.FindAll()) { outData.AppendLine($"{printer.Path}"); }


            return outData.ToString();
        }
    }
}
