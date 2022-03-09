using System.DirectoryServices;
using System.Collections.Generic;

namespace Coeus.Models.Data
{
    public class Data
    {
        public class Misc
        {
            public static string Prompt = $" > ";
            // Prompt = $" [{Domain}] >"
            public const string Ver = "v0.1";
        }

        public class DS
        {
            public static DirectoryEntry entry = new DirectoryEntry();
            public static DirectoryEntry RootDSE = new DirectoryEntry($"LDAP://RootDSE");
            public static DirectorySearcher searcher = new DirectorySearcher(entry);
            public static SearchScope scope = SearchScope.Subtree;
        }

        public class Lists
        {
            public static readonly List<Command> _commands = new List<Command>();
            public static readonly List<Util> _utils = new List<Util>();
        }

        public class Arrays
        {

            public static string[] defaultGroups = { "Domain Computers", "Domain Controllers", "Schema Admins", "Enterprise Admins",
            "Domain Admins", "Domain Users", "Domain Guests", "Group Policy Creator Owners", "Read-Only Domain Controllers",
            "Enterprise Read-Only Domain Controllers","Cloneable Domain Controllers", "Protected Users", "Key Admins", "Enterprise Key Admins",
            "DnsUpdateProxy"};

            public static string[] defaultUsers = { "Administrator", "Guest", "krbtgt" };

            public static string[] interestingCNs = { "*test*", "*dev*", "*prod*", "*svc*", "*admin*", "*adm*" };
        }

        public class Enums
        {
            public enum DomainFunctionality
            {
                DS_BEHAVIOR_WIN2000 = 0,
                DS_BEHAVIOR_WIN2003_WITH_MIXED_DOMAINS = 1,
                DS_BEHAVIOR_WIN2003 = 2,
                DS_BEHAVIOR_WIN2008 = 3,
                DS_BEHAVIOR_WIN2008R2 = 4,
                DS_BEHAVIOR_WIN2012 = 5,
                DS_BEHAVIOR_WIN2012R2 = 6,
                DS_BEHAVIOR_WIN2016 = 7
            }

            public enum ForestFunctionality
            {
                DS_BEHAVIOR_WIN2000 = 0,
                DS_BEHAVIOR_WIN2003_WITH_MIXED_DOMAINS = 1,
                DS_BEHAVIOR_WIN2003 = 2,
                DS_BEHAVIOR_WIN2008 = 3,
                DS_BEHAVIOR_WIN2008R2 = 4,
                DS_BEHAVIOR_WIN2012 = 5,
                DS_BEHAVIOR_WIN2012R2 = 6,
                DS_BEHAVIOR_WIN2016 = 7
            }

            public enum DCFunctionality
            {
                DS_BEHAVIOR_WIN2000 = 0,
                DS_BEHAVIOR_WIN2003 = 2,
                DS_BEHAVIOR_WIN2008 = 3,
                DS_BEHAVIOR_WIN2008R2 = 4,
                DS_BEHAVIOR_WIN2012 = 5,
                DS_BEHAVIOR_WIN2012R2 = 6,
                DS_BEHAVIOR_WIN2016 = 7
            }

            /*
             * idk write some thingy to convert OIDs to ints ig....maybe?
            public enum OIDs {
                LDAP_PAGED_RESULT_OID_STRING = 1.2.840.113556.1.4.319
            }
            */
        }

    }
}
