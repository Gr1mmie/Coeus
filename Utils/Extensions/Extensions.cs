using System;
using System.Reflection;
using System.DirectoryServices;
using System.Security.Principal;

using static System.Console;

using static Coeus.Utils.Init;
using static Coeus.Models.Data.Data;

namespace Coeus.Utils
{
    class Extensions
    {
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
    }
}
