using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands
{
    public class GPOQuery : Command
    {
        public override string CommandName => "GPOQuery"; 
        public override string CommandDesc => "Return data on a specified GPO";
        public override string CommandUsage => "[*] Usage: GPOQuery [GPOName]";

        public override string CommandExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
