using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands
{
    public class SearchLAPS : Command
    {
        public override string CommandName => "LAPSSweep";

        public override string CommandDesc => "Search for LAPS plain-text credentials";

        public override string CommandExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
