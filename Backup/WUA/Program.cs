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
            bool showProgress = Convert.ToBoolean(arguments["showProgress"]);

            if (!install)
            {
                ShowHelp();
                return;
            }

            WUAManager wua = new WUAManager();

            try
            {
                wua.Start(showProgress);
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
        }
    }
}
