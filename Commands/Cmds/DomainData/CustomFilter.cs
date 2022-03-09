using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class CustomFilter : Command
    {
        public override string CommandName => "CustomFilter";

        public override string CommandDesc => "Query the domain using a custom filter";

        public override string CommandUsage => "[*] Usage: CustomFilter [LDAP filter]";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            string Filter = args[1];

            UI.FilterSet(DS.searcher, Filter, DS.scope);

            foreach (SearchResult result in DS.searcher.FindAll()) { outData.AppendLine($"{result}"); }

            return outData.ToString();
        }
    }
}
