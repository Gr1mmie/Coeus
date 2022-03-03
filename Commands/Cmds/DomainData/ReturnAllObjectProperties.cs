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
        public override string CommandName => "AllObjProperties";
        public override string CommandDesc => "Return all properties for a specified object";

        public override string CommandUsage => "[*] Usage: AllObjProperties <obj cn>" +
            "\n\t obj cn - object canonical name to query (positional)";

        public override string CommandExec(string[] args)
        {
            if (args is null) { throw new CoeusException("[-] AllObjProperties [obj cn]"); }

            obj = args[1];

            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all object properties for object {obj}");
            UI.FilterSet(searcher, $"(cn={obj})", scope);

            var _out = searcher.FindOne();
            if (_out is null) { throw new CoeusException($"[-] {obj} not a valid CN\n"); }

            outData.AppendLine($"[*] Search Filter: {searcher.Filter}\n[*] Object Path: {_out.Path}\n");
            foreach (var property in searcher.FindOne().Properties.PropertyNames) { outData.AppendLine($"{property,-30}: {searcher.FindOne().Properties[(string)property][0]}"); }

            return outData.ToString();
        }
    }
}
