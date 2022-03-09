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

        public override string CommandExec(string[] args) {

            if (args is null || args.Length != 3) { throw new CoeusException($"[*] Usage ObjProperty [obj name] [prop name]"); }

            string ObjName = args[1];
            string ObjProp = args[2];
            ResultPropertyValueCollection cProp = null;

            try {

                StringBuilder outData = new StringBuilder();
                
                UI.FilterSet(DS.searcher, $"(cn={ObjName})", DS.scope);

                UI.SearchBanner(DS.searcher.Filter);
                foreach (SearchResult obj in DS.searcher.FindAll()) {
                    cProp = obj.Properties[$"{ObjProp}"];
                    if (ObjProp == "objectguid") { outData.AppendLine($"{DomainUtils.ConvertToGUID(cProp)}"); }
                    else if (ObjProp == "objectsid") { outData.AppendLine($"{DomainUtils.ConvertToSID(cProp)}"); }
                    else { outData.AppendLine($"{cProp[0]}"); }
                }

                return outData.ToString();
            }
            catch (System.ArgumentOutOfRangeException) { throw new CoeusException($"[-] Property {ObjProp} does not exist within object {ObjName}"); }
        }
    }
}
