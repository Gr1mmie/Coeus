using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnGroupMembers : Command
    {
        public override string CommandName => "GroupMembers";

        public override string CommandDesc => "Return users part of specified group";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all group objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, "(&(samaccounttype=268435456))", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult group in searcher.FindAll()) { outData.AppendLine($"{group.Properties["CN"][0],-25}: {group.Path}"); }

            return outData.ToString();
        }
    }
}
