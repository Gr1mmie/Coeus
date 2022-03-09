using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class ReturnDomain : Command
    {
        public override string CommandName => "Domain";

        public override string CommandDesc => "Return current domain";

        public override string CommandUsage => "[*] Usage: Domain";

        public override string CommandExec(string[] args)
        {
            return $"[*] Current domain: {DomainUtils.CurrentDomain(DS.searcher)}";
        }
    }
}
