using System;
using System.Linq;
using System.Reflection;
using System.DirectoryServices;

using Coeus.Models;

using static System.Console;

using static Coeus.Models.Data.Data;

namespace Coeus.Utils
{
    class UI
    {
        public static void Banner() {
            WriteLine(
                @"__   __                      " + "\n" +
                @"\ \ / /                      " + "\n" +
                @" \ v / ___  ___ _   _  ____  " + "\n" +
                @"  > < / _ \/ __) | | |/  ._) " + "\n" +
                @" / ^ ( (_) > _)| |_| ( () )  " + "\n" +
                @"/_/ \_\___/\___)\___/ \__/   " + "\n" +
                @"     Author: Grimmie         " + "\n" +
                $"       Ver: {Ver}            " + "\n"   
                );
        }

        public static void Action(string input) {
            try {

                if (input is "") { throw new CoeusException(""); }

                String[] opts = null;
                string _out = null;

                Init.InitAll();

                Command cmd = _commands.FirstOrDefault(cCmd => cCmd.CommandName.Equals(input.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));
                Util util = _utils.FirstOrDefault(cUtil => cUtil.UtilName.Equals(input.Split(' ')[0], StringComparison.InvariantCultureIgnoreCase));
                if (cmd is null && util is null) { throw new CoeusException($"[-] Command {input} is invalid"); }

                if (input.Contains(' ')) { opts = input.Split(' '); }

                if (cmd is null){ _out = util.UtilExec(opts); }
                else { _out = cmd.CommandExec(opts); }

                WriteLine(_out);
            }
            catch (NotImplementedException) { WriteLine($"[-] Util {input} not yet implemented"); }
            catch (CoeusException e) { WriteLine(e.Message); }
            catch (Exception e) { WriteLine($"{e}"); }
            
        }

        public static void SearchBanner(string filter) { WriteLine($"[*] Search Filter: {filter}\n[*] Search Results:\n"); }

        public static void FilterSet(DirectorySearcher searcher, string filter, SearchScope scope) {
            searcher.Filter = filter;
            searcher.SearchScope = scope;
        }

        public static void FilterSet(DirectorySearcher searcher, string filter, SearchScope scope, string[] Properties) {
            searcher.Filter = filter;
            searcher.SearchScope = scope;
            for (int i = 0; i < Properties.Length; i++) {
                searcher.PropertiesToLoad.Add(Properties[i]);
            }
        }

    }

    public class Init
    {

        public static void InitAll() {
            if (_commands.Count == 0) { CommandInit(); }
            if (_utils.Count == 0) { UtilInit(); }
        }

        public static void CommandInit() {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()) {
                if (type.IsSubclassOf(typeof(Command))) {
                    Command function = Activator.CreateInstance(type) as Command;
                    _commands.Add(function);
                }
            }
        }

        public static void UtilInit() {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()) {
                if (type.IsSubclassOf(typeof(Util))) {
                    Util function = Activator.CreateInstance(type) as Util;
                    _utils.Add(function);
                }
            }
        }
    }
}