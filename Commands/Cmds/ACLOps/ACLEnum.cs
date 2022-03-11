using System.Text;
using System.Linq;
using System.DirectoryServices;
using System.Security.Principal;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;
using static Coeus.Models.Data.Data.Enums;

namespace Coeus.Commands
{
    public class ACLEnum : Command
    {
        public override string CommandName => "ACLEnum";
        public override string CommandDesc => "Return ACL for specified object";
        public override string CommandUsage => "[*] Usage: ACLEnum [obj cn] <Rights> <ControlType> <IdentityReference>" +
            "\n\t obj cn - canonical name for object" +
            "\n\t Rights - return ACEs matching specified ActiveDirectoryRights (i.e GenericAll, WriteDACL,)" +
            "\n\t\t ACLEnum UserObject ReadProperty,WriteDACL" +
            "\n\t ControlType - return ACEs matching ControlType (Allow/Deny)" +
            "\n\t\t ACLEnum UserObject ReadProperty,WriteDACL Allow" +
            "\n\t\t IdentityReference - return ACEs matching IndentityReference (WIP)";

        public override string CommandExec(string[] args)
        {
            string CN;
            string[] ADRights = Arrays.ADRights;

            bool AllRights = false;

            ControlType ct = ControlType.Inactive;

            if (args != null && args.Length > 4) { throw new CoeusException("[*] Usage: ACLEnum [obj cn]"); }
            else if (args.Length == 3)
            {
                CN = args[1].Replace('.', ' ');
                if (args[2] == "*") { AllRights = true; } else { ADRights = args[2].Split(','); }
            }
            else if (args.Length == 4 && (args[3].ToLower() is "allow" || args[3].ToLower() is "deny"))
            {
                CN = args[1].Replace('.', ' ');
                if (args[2] == "*") { AllRights = true; } else { ADRights = args[2].Split(','); }
                if (args[3].ToLower() == "allow") { ct = ControlType.Allow; }
                if (args[3].ToLower() == "deny") { ct = ControlType.Deny; }
            }
            else { CN = args[1].Replace('.', ' '); }

            StringBuilder outData = new StringBuilder();

            UI.FilterSet(DS.searcher, $"(cn={CN})", DS.scope);
            ActiveDirectorySecurity objACL = DS.searcher.FindOne().GetDirectoryEntry().ObjectSecurity;

            foreach (ActiveDirectoryAccessRule ACE in objACL.GetAccessRules(true, true, typeof(NTAccount)))
            {
                if (ADRights != Arrays.ADRights || AllRights)
                {
                    if (ADRights.Any(ACE.ActiveDirectoryRights.ToString().Contains) && ct != ControlType.Inactive)
                    {
                        outData = ACLUtils.returnACEData(outData, ACE, ct);
                    }
                    else if (ADRights.Any(ACE.ActiveDirectoryRights.ToString().Contains)) { outData = ACLUtils.returnACEData(outData, ACE); }
                }
                else { outData = ACLUtils.returnACEData(outData, ACE); }
            }

            return outData.ToString();
        }
    }
}
