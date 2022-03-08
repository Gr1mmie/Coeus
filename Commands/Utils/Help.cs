using System;
using System.Linq;
using System.Text;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands
{
    public class Help : Util
    {
        public override string UtilName => "Help";

        public override string UtilDesc => "Display usage for a command";

        public override string UtilExec(string[] args) {
            if (args is null || args.Length > 2) { throw new CoeusException("[*] Usage: Help [command]\n"); }
            string qCmd = args[1];

            StringBuilder outData = new StringBuilder();

            Init.InitAll();

            Command cmd = _commands.FirstOrDefault(cCmd => cCmd.CommandName.Equals(qCmd, StringComparison.InvariantCultureIgnoreCase));
            if (cmd is null) { throw new CoeusException($"[-] Command {qCmd} is invalid\n"); }

            outData.AppendLine(cmd.CommandUsage);

            return outData.ToString();
        }
    }
}
