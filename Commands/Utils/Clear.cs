using System;

using Coeus.Models;

namespace Coeus.Commands
{
    public class Clear : Util
    {
        public override string UtilName => "Clear";

        public override string UtilDesc => "clear the screen";

        public override string UtilExec(string[] args) {
            Console.Clear();
            return "";
        }
    }
}
