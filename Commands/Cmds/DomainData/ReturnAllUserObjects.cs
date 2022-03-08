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

        public override string CommandUsage => "[*] Usage: AllUsers <user obj cn> <ndU/enabled/disabled/nPE/nPR/groups/admins>" +
            "\n\t user obj cn - canonical name for user object (positional)" +
            "\n\t ndU - return only nondefault users" +
            "\n\t enabled - return only enabled user objects" +
            "\n\t disabled - return only disabled user objects" +
            "\n\t nPE - return user objects whose passwords don't expire" +
            "\n\t nPR - return user objects that don't require a passwd" +
            "\n\t admins - returns user objects w/ admincount property set to 1";

        public override string CommandExec(string[] args)
        {
            bool NonDefaultUsers = false;
            string addFilter = "";
            
            if (args != null) {
                if (args.Length > 3) { throw new CoeusException("[*] Usage: AllUsers <user obj cn> <nondefaultUsers/enabled/disabled/noPasswdExpire>"); }

                if (args.Any("nPE".Contains)) { addFilter += "(userAccountControl:1.2.840.113556.1.4.803:=65536)"; }
                if (args.Any("enabled".Contains) && !args.Any("disabled".ToLower().Contains)) { addFilter += "(!(userAccountControl:1.2.840.113556.1.4.803:=2))"; }
                if (args.Any("disabled".Contains) && !args.Any("disabled".ToLower().Contains)) { addFilter += "(userAccountControl:1.2.840.113556.1.4.803:=2)"; }
                if (args.Any("nPR".Contains)) { addFilter += ""; }
                if (args.Any("admins".Contains)) { addFilter += "(admincount=1)"; }
                if (args.Any("ndU".ToLower().Contains)) { NonDefaultUsers = true; }
                if ((args.Length == 2 || args.Length == 3) && args[1].ToLower() != "true") { addFilter = $"(cn={args[1]})"; }
            }
            int count = 0;

            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all user objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, $"(&(samaccounttype=805306368)(objectcategory=person){addFilter})", scope);

            UI.SearchBanner(searcher.Filter);

            if (NonDefaultUsers)
            {
                foreach (SearchResult user in searcher.FindAll())
                {
                    if (!(defaultUsers.Any(user.Properties["CN"][0].ToString().Contains)))
                    {
                        count += 1;
                        outData.AppendLine($"{user.Properties["CN"][0],-25} : {user.Path} ");
                    }
                }
            }
            else
            {
                foreach (SearchResult user in searcher.FindAll())
                {
                    count += 1;
                    outData.AppendLine($"{user.Properties["CN"][0],-25}: {user.Path}");
                }
            }

            outData.AppendLine($"\n[*] Located {count} user objects");

            return outData.ToString();
        }
    }
}
