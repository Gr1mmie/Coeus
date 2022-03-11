using System.ComponentModel;
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

            public static string[] ADRights = { "GenericAll", "GenericRead", "GenericWrite", "GenericExecute", "ReadProperty", "ReadControl",
                "WriteProperty", "WriteOwner", "WriteDacl", "ListChildren", "ListObject", "CreateChild", "Delete", "DeleteChild", "DeleteTree",
                "ExtendedRight", "Self", "Syncronize", "AccessSystemSecurity"};
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
            public enum ControlType
            {
                Inactive = 0,
                Deny = 1,
                Allow = 2
            }

            public enum BuiltinSID
            {
                [Description("Administrators")]
                Administrators = 544,
                [Description("Users")]
                Users = 545,
                [Description("Guests")]
                Guests = 546,
                [Description("Power Users")]
                Power_Users = 547,
                [Description("Account Operators")]
                Account_Operators = 548,
                [Description("Server Operators")]
                Server_Operators = 549,
                [Description("Print Operators")]
                Print_Operators = 550,
                [Description("Backup Operators")]
                Backup_Operators = 551,
                [Description("Replicators")]
                Replicators = 552,
                [Description("Builtin\\Pre-Windows 2000 Compatable Access")]
                PreWin2000 = 554,
                [Description("Builtin\\Remote Desktop Users")]
                RemoteDesktopUsers = 555,
                [Description("Builtin\\Network Configuration Operators")]
                NetConfigOperators = 556,
                [Description("Builtin\\Incoming Forest Trust Builders")]
                IncomingForestTrustBuilders = 557,
                [Description("Builtin\\Performance Monitor Users")]
                PerformanceMonitorUsers = 558,
                [Description("Builtin\\Performance Log Users")]
                PerformanceLogUsers = 559,
                [Description("Builtin\\Windows Authorization Access Group")]
                WinAuthGroup = 560,
                [Description("Builtin\\Terminal Server License Servers")]
                TerminalSvr = 561,
                [Description("Builtin\\Distributed COM Users")]
                DCOMUsers = 562,
                [Description("Builtin\\Cryptographic Operators")]
                CrytpoOperators = 569,
                [Description("Builtin\\Event Log Readers")]
                EventLogReaders = 573,
                [Description("Builtin\\Certificate Service DCOM Access")]
                CSDCOMAccess = 574,
                [Description("Builtin\\RDS Remote Access Servers")]
                RemoteAccessSvr = 575,
                [Description("Builtin\\RDS Endpoint Servers")]
                RDSESvr = 576,
                [Description("Builtin\\RDS Management Servers")]
                RDSMSvr = 577,
                [Description("Builtin\\Hyper-V Administrators")]
                HVAdmins = 578,
                [Description("Builtin\\Access Control Assistance Operators")]
                ACAOperators = 579,
                [Description("Builtin\\Remote Management Users")]
                RemoteManageUsers = 580

            }
        }

    }
}
