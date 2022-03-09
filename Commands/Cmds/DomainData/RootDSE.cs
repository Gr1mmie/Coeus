using System.Text;

using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class RootDSE : Command
    {
        public override string CommandName => "RootDSE";

        public override string CommandDesc => "Returns data on domain RootDSE";

        public override string CommandUsage => "[*] Usage: RootDSE <property>" +
            "\n\t <property> - property to return";

        public override string CommandExec(string[] args)
        {
            string prop = null;

            if (args != null && args.Length > 2) { throw new CoeusException("[*] Usage: RootDSE <property>"); }
            if (args != null) { prop = args[1]; }

            int index;

            StringBuilder outData = new StringBuilder();
            if (prop != null && prop != " ")
            {
                var cProp = DS.RootDSE.Properties[$"{prop}"].Value;
                if (prop == "domainFunctionality")
                {
                    index = System.Int32.Parse(cProp.ToString());
                    outData.AppendLine($"{prop,-30}: {(Enums.DomainFunctionality)index}");
                }
                else if (prop == "forestFunctionality")
                {
                    index = System.Int32.Parse(cProp.ToString());
                    outData.AppendLine($"{prop,-30}: {(Enums.ForestFunctionality)index}");
                }
                else if (prop == "domainControllerFunctionality")
                {
                    index = System.Int32.Parse(cProp.ToString());
                    outData.AppendLine($"{prop,-30}: {(Enums.DCFunctionality)index}");
                }
                else if (cProp.GetType() == typeof(System.Object[]))
                {
                    outData.AppendLine($"{prop}:");
                    for (int i = 0; i < DS.RootDSE.Properties[$"{prop}"].Count; i++) { outData.AppendLine($"\t\t - {DS.RootDSE.Properties[$"{prop}"][i]}"); }
                }
                else { outData.AppendLine($"{DS.RootDSE.Properties[$"{prop}"][0]}"); }
            }
            else
            {
                foreach (var propName in DS.RootDSE.Properties.PropertyNames)
                {
                    var cProp = DS.RootDSE.Properties[$"{propName}"].Value;
                    if (cProp.GetType() == typeof(System.Object[]))
                    {
                        outData.AppendLine($"{propName}:");
                        for (int i = 0; i < DS.RootDSE.Properties[$"{propName}"].Count; i++) { outData.AppendLine($"\t\t - {DS.RootDSE.Properties[$"{propName}"][i]}"); }
                    }
                    else if ((string)propName == "domainFunctionality")
                    {
                        index = System.Int32.Parse(cProp.ToString());
                        outData.AppendLine($"{propName,-30}: {(Enums.DomainFunctionality)index}");
                    }
                    else if ((string)propName == "forestFunctionality")
                    {
                        index = System.Int32.Parse(cProp.ToString());
                        outData.AppendLine($"{propName,-30}: {(Enums.ForestFunctionality)index}");
                    }
                    else if ((string)propName == "domainControllerFunctionality")
                    {
                        index = System.Int32.Parse(cProp.ToString());
                        outData.AppendLine($"{propName,-30}: {(Enums.DCFunctionality)index}");
                    }
                    else { outData.AppendLine($"{propName,-30 }: {cProp}"); }
                }
            }
            return outData.ToString();
        }
    }
}
