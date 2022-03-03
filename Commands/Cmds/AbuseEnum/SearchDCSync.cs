using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class SearchDCSync : Command
    {
        public override string CommandName => "DCSync";

        public override string CommandDesc => "[*] Return objects w/ DCSync permissions";

        public override string CommandUsage => "[*] Usage: DCSync";

        public override string CommandExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();



            return outData.ToString();
        }
    }
}
