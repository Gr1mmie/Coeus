using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands
{
    public class GPOHunter : Command
    {
        public override string CommandName  => "GPOHunter";
        public override string CommandDesc  => "Return all GPOs";
        public override string CommandUsage => "[*] Usage: GPOHunter";

        public override string CommandExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
