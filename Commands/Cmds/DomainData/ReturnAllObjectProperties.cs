﻿using System.Text;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnAllObjectProperties : Command
    {
        public override string CommandName => "AllObjProperties";
        public override string CommandDesc => "Return all properties for a specified object";

        public override string CommandUsage => "[*] Usage: AllObjProperties <obj cn>" +
            "\n\t obj cn - object canonical name to query (positional)";

        public override string CommandExec(string[] args)
        {
            if (args is null) { throw new CoeusException("[-] AllObjProperties [obj cn]"); }

            string obj = args[1].Replace('.', ' ');

            StringBuilder outData = new StringBuilder();

            outData.AppendLine($"[*] Returning all object properties for object {obj}");
            UI.FilterSet(DS.searcher, $"(cn={obj})", DS.scope);

            var _out = DS.searcher.FindOne();
            if (_out is null) { throw new CoeusException($"[-] {obj} not a valid CN\n"); }

            outData.AppendLine($"[*] Search Filter: {DS.searcher.Filter}\n[*] Object Path: {_out.Path}\n");
            foreach (var property in DS.searcher.FindOne().Properties.PropertyNames) {
                if (property.ToString() == "objectguid") {
                    outData.AppendLine($"{property,-30}: {DomainUtils.ConvertToGUID(DS.searcher.FindOne().Properties[(string)property])}");
                } else if (property.ToString() == "objectsid") {
                    outData.AppendLine($"{property,-30}: {DomainUtils.ConvertToSID(DS.searcher.FindOne().Properties[(string)property])}");
                } else { outData.AppendLine($"{property,-30}: {DS.searcher.FindOne().Properties[(string)property][0]}"); }
            }

            return outData.ToString();
        }
    }
}
