using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class GPOQuery : Command
    {
        public override string CommandName => "GPOQuery";
        public override string CommandDesc => "Return data on a specified GPO";

        public override string CommandUsage => "[*] Usage: GPOQuery [GPO Id] <GPO Prop>" +
            "\n\t GPO Id - GPO id to query. Can be found using GPOHunter" +
            "\n\t GPO Prop - GPO property to return";
        public override string CommandExec(string[] args) {
            try {

                string Prop = null;
                string GPOId = null;

                if (args is null || args.Length > 3) { throw new CoeusException("[*] Usage: GPOQuery [GPO Id] <GPO Prop>\n"); }
                if (args.Length == 3) {
                    GPOId = args[1];
                    Prop = args[2];
                } else { GPOId = args[1]; }

                StringBuilder outData = new StringBuilder();

                UI.FilterSet(searcher, $"(&(ObjectCategory=groupPolicyContainer)(cn={'{' + GPOId + '}'}))", scope);

                UI.SearchBanner("(ObjectCategory=groupPolicyContainer)");
                if (Prop == null) {
                    foreach (var GPOProp in searcher.FindOne().Properties.PropertyNames) {
                        outData.AppendLine($"{GPOProp,-30}: {searcher.FindOne().Properties[$"{GPOProp}"][0]}");
                    }
                } else if (Prop != null && Prop != "") {
                    foreach (SearchResult GPOProp in searcher.FindAll()) {
                        outData.AppendLine($"{GPOProp.Properties[$"{Prop}"][0]}");
                    }
                }

                return outData.ToString();
            } catch (System.IndexOutOfRangeException) { throw new CoeusException($"[-] Property doesn't exist\n"); }
        }
    }
}
