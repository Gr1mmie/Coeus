using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class GPOHunter : Command
    {
        public override string CommandName => "GPOHunter";
        public override string CommandDesc => "Return all GPOs";
        public override string CommandUsage => "[*] Usage: GPOHunter";

        public override string CommandExec(string[] args)
        {
            if (args != null) { throw new CoeusException("[*] Usage: GPOHunter\n"); }

            StringBuilder outData = new StringBuilder();

            UI.FilterSet(searcher, "(ObjectCategory=groupPolicyContainer)", scope);

            UI.SearchBanner("(ObjectCategory=groupPolicyContainer)");
            foreach (SearchResult gpo in searcher.FindAll()) { outData.AppendLine($"{gpo.Path}"); }

            return outData.ToString();
        }
    }
}
