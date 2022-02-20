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

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all user objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, "(&(samaccounttype=805306368)(objectcategory=person))", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult user in searcher.FindAll()) { outData.AppendLine($"{user.Properties["CN"][0],-25}: {user.Path}"); }

            return outData.ToString();
        }
    }
}
