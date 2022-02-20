using System;

using Coeus.Models;

namespace Coeus.Commands
{
    public class Exit : Util
    {
        public override string UtilName => "Exit";

        public override string UtilDesc => "Exit Coeus";

        public override string UtilExec(string[] args) {
            Environment.Exit(0);
            return "";
        }
    }
}
