using System.Text;
using System.DirectoryServices;

using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnGroupMembers : Command
    {
        public override string CommandName => "GroupMembers";

        public override string CommandDesc => "Return users part of specified group";

        public override string CommandUsage => "[*] Usage: GroupMembers [group name]" +
            "\n\t group name - group name to return members of";

        public override string CommandExec(string[] args) {
            string group = "";

            if (args != null && args.Length == 2) { group = $"{args[1].Replace('.', ' ')}"; }
            else { throw new CoeusException("[-] No group supplied\n"); }

            StringBuilder outData = new StringBuilder();

            string domainPath = DS.RootDSE.Properties["defaultNamingContext"][0].ToString();

            DirectoryEntry groupEntry = new DirectoryEntry($"LDAP://CN={group},CN=Users,{domainPath}");

            foreach (var member in groupEntry.Properties["Member"]) { outData.AppendLine(member.ToString()); }


            return outData.ToString();
        }
    }
}
