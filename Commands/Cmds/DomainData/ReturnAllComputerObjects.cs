using System.Linq;
using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnAllComputerObjects : Command
    {
        private bool OSSearch { get; set; }
        public override string CommandName => "AllComputers";

        public override string CommandDesc => "Return all computer objects";

        public override string CommandUsage => "[*] Usage: AllComputers <OS>\n\tOS - Include OS and Version if available";

        public override string CommandExec(string[] args)
        {
            int count = 0;
            ResultPropertyCollection cProp = null;

            if (args != null && args.Any("OS".Contains)) { OSSearch = true; }
            else { OSSearch = false; }

            StringBuilder outData = new StringBuilder();
            outData.AppendLine($"[*] Returning all computer objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, "(objectclass=computer)", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult group in searcher.FindAll())
            {
                count += 1;
                cProp = group.Properties;
                outData.AppendLine($"{cProp["CN"][0],-25}: {group.Path}");
                if (OSSearch && (cProp["OperatingSystem"].Count == 1))
                {
                    outData.AppendLine($"\tOS: {cProp["OperatingSystem"][0]}\n\tVer: {cProp["OperatingSystemVersion"][0]}");
                }
            }

            outData.AppendLine($"\n[*] Located {count} computer objects");

            return outData.ToString();
        }
    }
}
