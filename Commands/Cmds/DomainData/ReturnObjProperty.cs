using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnObjProperty : Command
    {
        public override string CommandName => "ObjProperty";

        public override string CommandDesc => "Return specified property from obj";

        public override string CommandUsage => "[*] Usage: ObjProperty [obj cn] [propName]" +
            "\n\t obj cn - object to query" +
            "\n\t propName - property to return";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            if (args is null || args.Length != 3) { throw new CoeusException($"[*] Usage ObjProperty [obj name] [prop name]"); }

            string objName = args[1];
            string objProp = args[2];

            UI.FilterSet(searcher, $"(cn={objName})", scope);

            UI.SearchBanner(searcher.Filter);
            foreach (SearchResult obj in searcher.FindAll()) { outData.AppendLine($"{obj.Properties[$"{objProp}"]}"); }


            return outData.ToString();
        }
    }
}
