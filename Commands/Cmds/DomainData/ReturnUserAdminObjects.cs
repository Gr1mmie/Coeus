using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnUserAdminObjects : Command
    {
        public override string CommandName => "Admins";

        public override string CommandDesc => "Return user objects marked as admins";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Locating admin objects within the {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, "(&(samaccounttype=805306368)(admincount=1))", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult admin in searcher.FindAll()) { outData.AppendLine($"{admin.Properties["CN"][0],-25}: {admin.Path}"); }

            return outData.ToString();
        }
    }
}
