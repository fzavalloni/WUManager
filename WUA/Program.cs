using System;
using WUApiLib;

namespace WUA
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments arguments = new Arguments(args);

            bool install = Convert.ToBoolean(arguments["install"]);
            bool countUpdates = Convert.ToBoolean(arguments["countUpdates"]);
            bool showProgress = Convert.ToBoolean(arguments["showProgress"]);

            WUAManager wua = new WUAManager();

            try
            {
                if (install)
                {
                    wua.Start(showProgress);
                }
                else if (countUpdates)
                {
                    wua.CountPendingUpdates();
                }
                else
                {
                    ShowHelp();
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("WUA_InternalError:{0}", ex.Message);
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("WUManager HELP");
            Console.WriteLine();
            Console.WriteLine("Syntax:");
            Console.WriteLine("WUA /install");
            Console.WriteLine("WUA /install /showProgress");
            Console.WriteLine("WUA /countUpdates");
        }
    }
}
