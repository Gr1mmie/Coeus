using System.Text;
using System.DirectoryServices.ActiveDirectory;

using Coeus.Models;

namespace Coeus.Commands
{
    public class ReturnForestData : Command
    {
        public override string CommandName => "ForestData";

        public override string CommandDesc => "Return information on forest";

        public override string CommandUsage => "[*] Usage: ForestData";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();
            string Roles = null;

            Forest forestData = Forest.GetCurrentForest();

            outData.AppendLine($"{"ForestName",-20}: {forestData.Name}");
            outData.AppendLine($"{"ForestModeLevel",-20}: {forestData.ForestModeLevel}");
            if (!(forestData.ForestMode.ToString() == "Unknown")) { outData.AppendLine($"{"ForestMode",-20}: {forestData.ForestMode}"); }

            outData.AppendLine($"{"RootDomain",-20}: {forestData.RootDomain}");

            outData.AppendLine($"Domains:");
            foreach (Domain domain in forestData.Domains) { outData.AppendLine($"\t{domain}"); }

            outData.AppendLine($"Global Catalogs:");
            foreach (GlobalCatalog GC in forestData.GlobalCatalogs)
            {
                for (int i = 0; i < GC.Roles.Count; i++) { Roles += $" {GC.Roles[i]}"; }
                outData.AppendLine($"\t{nameof(GC.Name)}: {GC.Name}" +
                    $"\n\t{nameof(GC.IPAddress)}: {GC.IPAddress}" +
                    $"\n\t{nameof(GC.OSVersion)}: {GC.OSVersion}" +
                    $"\n\t{nameof(GC.Domain)}: {GC.Domain}" +
                    $"\n\t{nameof(GC.Roles)}:{Roles}\n");
            }

            outData.AppendLine($"Partitions: ");
            foreach (ApplicationPartition partition in forestData.ApplicationPartitions) { outData.AppendLine($"\t{partition}"); }

            forestData.Dispose();

            return outData.ToString();
        }
    }
}
