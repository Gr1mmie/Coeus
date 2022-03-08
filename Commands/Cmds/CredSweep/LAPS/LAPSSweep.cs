using System.Text;

using Coeus.Models;

namespace Coeus.Commands
{
    public class SearchLAPS : Command
    {
        public override string CommandName => "LAPSSweep";

        public override string CommandDesc => "Search for LAPS plain-text credentials";
        public override string CommandUsage => "[*] Usage: LAPSweep";

        public override string CommandExec(string[] args)
        {

            // ([adsisearcher]"(&(objectCategory=computer)(ms-MCS-admpwdexpirationtime=*))").findAll().GetdirectoryEntry()
            StringBuilder outData = new StringBuilder();

            return outData.ToString();

        }
    }
}
