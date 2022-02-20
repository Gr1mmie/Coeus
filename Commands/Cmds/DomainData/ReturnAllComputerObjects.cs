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
        public override string CommandName => "AllComputers";

        public override string CommandDesc => "Return all computer objects";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all computer objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, "(objectclass=computer)", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult group in searcher.FindAll()) { outData.AppendLine($"{group.Properties["CN"][0],-25}: {group.Path}"); }
            
            return outData.ToString();
        }
    }
}
