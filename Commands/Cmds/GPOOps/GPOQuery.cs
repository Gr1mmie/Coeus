using System.Text;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class GPOQuery : Command
    {
        private static string GPOId { get; set; }
        public override string CommandName => "GPOQuery";
        public override string CommandDesc => "Return data on a specified GPO";

        public override string CommandUsage => "[*] Usage: GPOQuery [GPO Id]";
        public override string CommandExec(string[] args)
        {
            if (args is null || args.Length > 2) { throw new CoeusException("[*] Usage: GPOQuery [GPO Id]\n"); }
            else { GPOId = args[1]; }

            StringBuilder outData = new StringBuilder();

            UI.FilterSet(searcher, $"(&(ObjectCategory=groupPolicyContainer)(cn={'{' + GPOId + '}'}))", scope);

            UI.SearchBanner("(ObjectCategory=groupPolicyContainer)");
            foreach (var GPOProp in searcher.FindOne().Properties.PropertyNames) {
                outData.AppendLine($"{GPOProp,-30}: {searcher.FindOne().Properties[(string)GPOProp][0]}");
            }

            return outData.ToString();
        }
    }
}
