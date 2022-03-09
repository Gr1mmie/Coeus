using System.Text;

using Coeus.Utils;
using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands.Utils
{
    public class Commands : Util
    {
        public override string UtilName => "Commands";

        public override string UtilDesc => "List available commands";

        public override string UtilExec(string[] args)
        {
            StringBuilder _out = new StringBuilder();

            Init.InitAll();

            _out.AppendLine("\nCommands\n____________\n");
            foreach (Command cmd in Lists._commands) { _out.AppendLine($"{cmd.CommandName,-25} {cmd.CommandDesc}"); }

            _out.AppendLine("\nUtils\n____________\n");
            foreach (Util util in Lists._utils) { _out.AppendLine($"{util.UtilName,-25} {util.UtilDesc}"); }

            return _out.ToString();
        }
    }
}
