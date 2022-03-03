using System.Text;
using System.DirectoryServices;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Utils.Extensions;
using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class Help : Util
    {
        public override string UtilName => "Help";

        public override string UtilDesc => "Display usage for a command";

        public override string UtilExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();



            return outData.ToString();
        }
    }
}
