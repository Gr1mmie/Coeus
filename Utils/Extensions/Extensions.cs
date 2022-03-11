using System;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.DirectoryServices;
using System.Security.Principal;

using static Coeus.Models.Data.Data.Enums;


namespace Coeus.Utils
{
    static class Extensions
    {

        public static string ToDescription(this Enum value) {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public class DomainUtils
        {
            public static string CurrentDomain(DirectorySearcher searcher) { return (string)searcher.SearchRoot.Properties["dc"][0]; }

            public static Int64 ConvertLargeIntegerToInt64(object largeInteger) {
                Int32 highPart = (Int32)largeInteger.GetType().InvokeMember("HighPart", BindingFlags.GetProperty, null, largeInteger, null);
                Int32 lowPart = (Int32)largeInteger.GetType().InvokeMember("LowPart", BindingFlags.GetProperty, null, largeInteger, null);

                return ((Int64)highPart) << 32 + lowPart;
            }

            public static Guid ConvertToGUID(ResultPropertyValueCollection Property) { return new Guid((byte[])Property[0]); }

            public static SecurityIdentifier ConvertToSID(ResultPropertyValueCollection Property) {
                return new SecurityIdentifier((byte[])Property[0], 0);
            }

        }

        public class ACLUtils
        {

            public static StringBuilder returnACEData(StringBuilder sb, ActiveDirectoryAccessRule ACE)
            {
                sb.AppendLine($"{nameof(ACE.ActiveDirectoryRights),-25}: {ACE.ActiveDirectoryRights}\n" +
                    $"{nameof(ACE.AccessControlType),-25}: {ACE.AccessControlType}\n");
                if (ACE.IdentityReference.ToString().Contains("S-1-5-32")) {
                    Int32 index = Int32.Parse(ACE.IdentityReference.ToString().Split('-')[4]);
                    sb.AppendLine($"{nameof(ACE.IdentityReference),-25}: {((BuiltinSID)index).ToDescription()}");
                } else { sb.AppendLine($"{nameof(ACE.IdentityReference),-25}: {ACE.IdentityReference}"); }
                sb.AppendLine($"{nameof(ACE.ObjectType),-25}: {ACE.ObjectType}\n" +
                    $"{nameof(ACE.ObjectFlags),-25}: {ACE.ObjectFlags}");
                if (ACE.IsInherited) {
                    if (ACE.PropagationFlags.ToString() != "None") { sb.AppendLine($"{nameof(ACE.PropagationFlags),-25}: {ACE.PropagationFlags}"); }
                    sb.AppendLine($"{nameof(ACE.InheritanceFlags),-25}: {ACE.InheritanceFlags}\n" +
                        $"{nameof(ACE.InheritanceType),-25}: {ACE.InheritanceType}\n" +
                        $"{nameof(ACE.InheritedObjectType),-25}: {ACE.InheritedObjectType}");
                }

                sb.AppendLine();

                return sb;
            }

            public static StringBuilder returnACEData(StringBuilder sb, ActiveDirectoryAccessRule ACE, ControlType ct) {
                if (ct.Equals(Enum.Parse(typeof(ControlType), ACE.AccessControlType.ToString())))
                {
                    sb.AppendLine($"{nameof(ACE.ActiveDirectoryRights),-25}: {ACE.ActiveDirectoryRights}\n" +
                        $"{nameof(ACE.AccessControlType),-25}: {ACE.AccessControlType}\n");
                    if (ACE.IdentityReference.ToString().Contains("S-1-5-32")) {
                        Int32 index = Int32.Parse(ACE.IdentityReference.ToString().Split('-')[4]);
                        sb.AppendLine($"{nameof(ACE.IdentityReference),-25}: {((BuiltinSID)index).ToDescription()}");
                    } else { sb.AppendLine($"{nameof(ACE.IdentityReference),-25}: {ACE.IdentityReference}"); }
                    sb.AppendLine($"{nameof(ACE.ObjectType),-25}: {ACE.ObjectType}\n" +
                        $"{nameof(ACE.ObjectFlags),-25}: {ACE.ObjectFlags}");
                    if (ACE.IsInherited)
                    {
                        if (ACE.PropagationFlags.ToString() != "None") { sb.AppendLine($"{nameof(ACE.PropagationFlags)}: {ACE.PropagationFlags}"); }
                        sb.AppendLine($"{nameof(ACE.InheritanceFlags),-25}: {ACE.InheritanceFlags}\n" +
                            $"{nameof(ACE.InheritanceType),-25}: {ACE.InheritanceType}\n" +
                            $"{nameof(ACE.InheritedObjectType),-25}: {ACE.InheritedObjectType}");
                    }
                    sb.AppendLine();
                }

                return sb;
            }

            public static string ConvertSIDToName() {
                return "";
            }
        }
    }
}
