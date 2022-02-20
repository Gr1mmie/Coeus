using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnAllObjectProperties : Command
    {
        private string obj { get; set; }
        public override string CommandName => "AllObjectProperties";
        public override string CommandDesc => "Return all properties for a specified object";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all object properties for object {obj}");
            UI.FilterSet(searcher, $"(cn={obj})", scope);

            outData.AppendLine($"[*] Search Filter: {searcher.Filter}\n[*] Object Path: {searcher.FindOne().Path}\n");
            foreach (var property in searcher.FindOne().Properties.PropertyNames) { outData.AppendLine($"{property,-25}: {searcher.FindOne().Properties[(string)property][0]}"); }

            return outData.ToString();
        }
    }
}
