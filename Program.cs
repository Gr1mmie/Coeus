using Coeus.Utils;

using static System.Console;

using static Coeus.Models.Data.Data;

namespace Coeus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UI.Banner();

            while(true) {
                Write($"{Misc.Prompt}");

                UI.Action(ReadLine());
            }
        }
    }
}
