using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands
{
    public class SearchDelegation : Command
    {
        public override string CommandName => "DelegateSearch";

        public override string CommandDesc => "Search for machines succeptable to delegation attacks";

        public override string CommandExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
