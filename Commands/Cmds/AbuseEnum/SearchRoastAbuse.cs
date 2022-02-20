using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands
{
    public class SearchRoast : Command
    {
        public override string CommandName => "RoastSearch";

        public override string CommandDesc => "Search for machines succeptable to roasting attacks";

        public override string CommandExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
