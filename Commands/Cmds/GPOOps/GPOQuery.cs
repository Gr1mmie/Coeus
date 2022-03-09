using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class GPOQuery : Command
    {
        public override string CommandName => "GPOQuery";
        public override string CommandDesc => "Return data on a specified GPO";

        public override string CommandUsage => "[*] Usage: GPOQuery [GPO Id] <GPO Prop>";
        public override string CommandExec(string[] args)
        {
            if (args is null || args.Length > 3) { throw new CoeusException("[*] Usage: GPOQuery [GPO Id] <GPO Prop>\n"); }

            string Prop = null;
            string GPOId = null;
            ResultPropertyValueCollection cProp = null;

            if (args.Length == 3) {
                GPOId = args[1];
                Prop = args[2];
            } else { GPOId = args[1]; }


            try {

                StringBuilder outData = new StringBuilder();

                UI.FilterSet(DS.searcher, $"(&(ObjectCategory=groupPolicyContainer)(cn={'{' + GPOId + '}'}))", DS.scope);

                UI.SearchBanner($"(&(ObjectCategory = groupPolicyContainer)(cn={ '{' + GPOId + '}'}))");
                if (Prop == null) {
                    foreach (var GPOProp in DS.searcher.FindOne().Properties.PropertyNames) {
                        cProp = DS.searcher.FindOne().Properties[$"{GPOProp}"];
                        if (GPOProp.ToString() == "objectguid") {
                            outData.AppendLine($"{GPOProp,-30}: {DomainUtils.ConvertToGUID(cProp)}");
                        } else { outData.AppendLine($"{GPOProp,-30}: {cProp[0]}"); }
                    }
                } else if (Prop != null && Prop != "") {
                    foreach (SearchResult GPOProp in DS.searcher.FindAll()) {
                        cProp = GPOProp.Properties[$"{Prop}"];
                        if (Prop == "objectguid") {
                            outData.AppendLine($"{DomainUtils.ConvertToGUID(cProp)}");
                        } else { outData.AppendLine($"{cProp[0]}"); }
                    }
                }

                return outData.ToString();
            }
            catch (System.IndexOutOfRangeException) { throw new CoeusException($"[-] Property {Prop} doesn't exist\n"); }
        }
    }
}
