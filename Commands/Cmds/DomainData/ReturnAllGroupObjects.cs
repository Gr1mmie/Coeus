﻿using System.Linq;
using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnAllGroupObjects : Command
    {
        public override string CommandName => "AllGroups";

        public override string CommandDesc => "Return all group objects";

        public override string CommandUsage => "[*] Usage: AllGroups <group obj cn> <ndG>" +
            "\n\t group obj cn - canonical name for group object (positional)" +
            "\n\t ndG - returns only non default groups.";

        public override string CommandExec(string[] args)
        {
            bool NonDefaultGroups = false;
            string addFilter = "";
            int count = 0;

            if (args != null) {
                if (args.Length > 3) { throw new CoeusException("[*] Usage: AllGroups <group obj cn> <nondefaultGroups>\n"); }
                if ((args.Length == 2 || args.Length == 3) && args[1].ToLower() != "ndg") { addFilter = $"(cn={args[1]})"; }
                if (args.Any("ndG".ToLower().Contains)) { NonDefaultGroups = true; }
            }

            StringBuilder outData = new StringBuilder();
            outData.AppendLine($"[*] Returning all group objects in {DomainUtils.CurrentDomain(searcher)} domain");
            UI.FilterSet(searcher, $"(&(samaccounttype=268435456){addFilter})", scope);

            UI.SearchBanner(searcher.Filter);
            if (NonDefaultGroups)
            {
                foreach (SearchResult group in searcher.FindAll())
                {
                    if (!(defaultGroups.Any(group.Properties["CN"][0].ToString().Contains)))
                    {
                        count += 1;
                        outData.AppendLine($"{group.Properties["CN"][0],-25} : {group.Path} ");
                    }
                }
            }
            else
            {
                foreach (SearchResult group in searcher.FindAll())
                {
                    count += 1;
                    outData.AppendLine($"{group.Properties["CN"][0],-40} : {group.Path}");
                }
            }

            outData.AppendLine($"\n[*] Located {count} group objects");

            return outData.ToString();
        }
    }
}