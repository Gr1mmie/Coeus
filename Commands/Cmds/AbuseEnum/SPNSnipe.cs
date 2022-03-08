using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands.Cmds.AbuseEnum
{
    public class SPNSnipe : Command
    {
        private string Computer { get; set; } = "";
        private string Include { get; set; } = "!(samAccountName=krbtgt)";
        public override string CommandName => "SPNHunter";
        public override string CommandDesc => "Return SPNs for specified computer object";
        public override string CommandUsage => "[*] Usage: SPNHunter [Snipe/Spread] <includeKrbtgt>" +
            "\n\tSnipe - return SPNs for specified machine" +
            "\n\t\tSPNHunter Snipe [computer name] <includeKrbtgt>" +
            "\n\tSpread - returns all SPNs on the domain" +
            "\n\tincludeKrbtgt - include Krbtgt account in results";    

        public override string CommandExec(string[] args) {
            try {

                if (args is null) { throw new CoeusException("[*] Usage:\n\tSPNHunter Snipe [object cn]\n\tSPNHunter Spread <includeKrbtgt>"); }

                if (args.Length == 3 && args[1].ToLower().Contains("snipe")) { Computer = args[2]; }
                else if ((args.Length >= 2 && args.Length < 4) && args[1].ToLower().Contains("spread")) {
                    Computer = "*";
                    if (args.Length == 3 && args[2].ToLower().Contains("true")) { Include = ""; }
                }

                StringBuilder outData = new StringBuilder();

                UI.FilterSet(searcher, $"(&(cn={Computer})({Include}(servicePrincipalName=*)))", scope);

                var cObj = searcher.FindAll();
                foreach (SearchResult obj in cObj) {
                    var cEntry = obj.GetDirectoryEntry();
                    outData.AppendLine(cEntry.Name.Split('=')[1]);
                    foreach (string spn in cEntry.Properties["servicePrincipalName"]) { outData.AppendLine($"\t{spn}"); }
                }

                return outData.ToString();
            } catch (System.ArgumentException) { return $"[-] {Computer} is an invalid computer object within this domain\n"; }

        }
    }
}
