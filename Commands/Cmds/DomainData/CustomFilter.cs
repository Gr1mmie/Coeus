using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class CustomFilter : Command
    {
        private string Filter { get; set; }
        public override string CommandName => "CustomFilter";

        public override string CommandDesc => "Query the domain using a custom filter";

        public override string CommandUsage => "[*] Usage: CustomFilter [LDAP filter]";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            Filter = args[1];

            UI.FilterSet(searcher, Filter, scope);

            foreach (SearchResult result in searcher.FindAll()) { outData.AppendLine($"{result}"); }

            return outData.ToString();
        }
    }
}
