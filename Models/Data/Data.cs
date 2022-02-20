using System.DirectoryServices;
using System.Collections.Generic;

namespace Coeus.Models.Data
{
    public class Data {

        public static string Prompt = $" > ";
        // Prompt = $" [{Domain}] >"
        public const string Ver = "v0.1";

        public static DirectoryEntry entry = new DirectoryEntry();
        public static DirectorySearcher searcher = new DirectorySearcher(entry);
        public static SearchScope scope = SearchScope.Subtree;

        public static readonly List<Command> _commands = new List<Command>();
        public static readonly List<Util> _utils = new List<Util>();
    }
}
