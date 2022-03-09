using System.Text;

using Coeus.Models;

using static Coeus.Models.Data.Data;

namespace Coeus.Commands.Utils
{
    public class Banner : Util
    {
        public override string UtilName => "Banner";

        public override string UtilDesc => "Display banner";

        public override string UtilExec(string[] args)
        {
            StringBuilder outData = new StringBuilder();

            outData.AppendLine(
                @"__   __                      " + "\n" +
                @"\ \ / /                      " + "\n" +
                @" \ v / ___  ___ _   _  ____  " + "\n" +
                @"  > < / _ \/ __) | | |/  ._) " + "\n" +
                @" / ^ ( (_) > _)| |_| ( () )  " + "\n" +
                @"/_/ \_\___/\___)\___/ \__/   " + "\n" +
                @"     Author: Grimmie         " + "\n" +
                $"       Ver: {Misc.Ver}            " + "\n"
                );

            return outData.ToString();
        }
    }
}
