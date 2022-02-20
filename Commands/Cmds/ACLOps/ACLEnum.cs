using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands
{
    public class ACLEnum : Command
    {
        public override string CommandName => "ACLEnum";

        public override string CommandDesc => "Return ACL for specified object";

        public override string CommandExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
