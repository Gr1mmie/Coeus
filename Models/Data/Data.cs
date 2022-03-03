using System.DirectoryServices;
using System.Collections.Generic;

namespace Coeus.Models.Data
{
    public class Data
    {

        public static string Prompt = $" > ";
        // Prompt = $" [{Domain}] >"
        public const string Ver = "v0.1a";

        public static DirectoryEntry entry = new DirectoryEntry();
        public static DirectoryEntry RootDSE = new DirectoryEntry($"LDAP://RootDSE");
        public static DirectorySearcher searcher = new DirectorySearcher(entry);
        public static SearchScope scope = SearchScope.Subtree;

        public static readonly List<Command> _commands = new List<Command>();
        public static readonly List<Util> _utils = new List<Util>();

        public static string[] defaultGroups = { "Domain Computers", "Domain Controllers", "Schema Admins", "Enterprise Admins",
            "Domain Admins", "Domain Users", "Domain Guests", "Group Policy Creator Owners", "Read-Only Domain Controllers",
            "Enterprise Read-Only Domain Controllers","Cloneable Domain Controllers", "Protected Users", "Key Admins", "Enterprise Key Admins",
            "DnsUpdateProxy"};

        public static string[] defaultUsers = { "Administrator", "Guest", "krbtgt" };

        public static string[] interestingCNs = { "*test*", "*dev*", "*prod*", "*svc*", "*admin*", "*adm*" };
    }
}
