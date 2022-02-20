using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coeus.Models;

namespace Coeus.Commands.Utils
{
    public class Authenticate : Util
    {
        public override string UtilName => "Authenticate";

        public override string UtilDesc => "Create an authentication object";

        public override string UtilExec(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}