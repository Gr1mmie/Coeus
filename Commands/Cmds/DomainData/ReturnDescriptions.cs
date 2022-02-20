using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class DescriptionHunter : Command
    {
        private string desc { get; set; } = "*";
        public override string CommandName => "Descriptions";

        public override string CommandDesc => "Return descriptions";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Searching decriptions in {DomainUtils.CurrentDomain(searcher)} domain matching '{desc}'");
            UI.FilterSet(searcher, $"(&(objectclass=user)(description={desc}))", scope);

            UI.SearchBanner(searcher.Filter);
            outData.AppendLine($"[*] Search Filter: {searcher.Filter}\n[*] Search Results:\n");
            foreach (SearchResult acc in searcher.FindAll()) { outData.AppendLine($"{acc.Properties["CN"][0],-25}: {acc.Properties["Description"][0]}"); }

            return outData.ToString();
        }
    }
}
