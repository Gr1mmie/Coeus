using System.Linq;
using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnAllUserObjects : Command
    {
        public override string CommandName => "AllUsers";

        public override string CommandDesc => "Return all user objects";

        public override string CommandUsage => "[*] Usage: AllUsers <user obj cn> <ndU/enabled/disabled/nPE>" +
            "\n\t user obj cn - canonical name for user object (positional)" +
            "\n\t ndU - return only nondefault users" +
            "\n\t enabled - return only enabled user objects" +
            "\n\t disabled - return only disabled user objects" +
            "\n\t nPE - return user objects whose passwords don't expire" +
            "\n\t nPR - returns user objects that don't require a passwd";

        public override string CommandExec(string[] args)
        {
            bool NonDefaultUsers = false;
            string addFilter = "";
            int count = 0;

            string[] opts = new string[] { "ndU", "nPE", "nPR", "enabled", "disabled" };

            if (args != null) {
                if (args != null && args.Length > 3) { throw new CoeusException("[*] Usage: AllUsers <user obj cn> <ndU/enabled/disabled/nPE/nPR>"); }
                if (opts.Any(args[1].Contains)) { addFilter = $"(cn=*)"; } else { addFilter = $"(cn={args[1]})"; }
                if (args.Any("nPE".Contains)) { addFilter += "(userAccountControl:1.2.840.113556.1.4.803:=65536)"; }
                if (args.Any("nPR".Contains)) { addFilter += "(userAccountControl:1.2.840.113556.1.4.803:=32)"; }
                if (args.Any("enabled".Contains) && !args.Any("disabled".Contains)) { addFilter += "(!(userAccountControl:1.2.840.113556.1.4.803:=2))"; }
                if (args.Any("disabled".Contains) && !args.Any("disabled".Contains)) { addFilter += "(userAccountControl:1.2.840.113556.1.4.803:=2)"; }
                if (args.Any("ndU".Contains)) { NonDefaultUsers = true; }
            }

            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all user objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, $"(&(samaccounttype=805306368)(objectcategory=person){addFilter})", scope);

            UI.SearchBanner(searcher.Filter);

            if (NonDefaultUsers) {
                foreach (SearchResult user in searcher.FindAll()) {
                    if (!defaultUsers.Any(user.Properties["CN"][0].ToString().Contains)) {
                        count += 1;
                        outData.AppendLine($"{user.Properties["CN"][0],-25} : {user.Path} ");
                    }
                }
            } else {
                foreach (SearchResult user in searcher.FindAll()) {
                    count += 1;
                    outData.AppendLine($"{user.Properties["CN"][0],-25}: {user.Path}");
                }
            }

            outData.AppendLine($"\n[*] Located {count} user objects");

            return outData.ToString();
        }
    }
}
