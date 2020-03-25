using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadsKiller
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            KillThread("ModelDemo");        // ModelDemo
            KillThread("MonoLauncher");     // MonoLauncher
            KillThread("msvsmon");          // Visual Studio 2015 Remote Debugger
            Console.WriteLine("Program will automatically close soon.");
            Thread.Sleep(500);
        }

        private static void KillThread(string argName)
        {
            Process[] processItems = Process.GetProcessesByName(argName);
            if (processItems.Length == 0)
            {
                Console.WriteLine($"Cannot find process \"{argName}\"");
                return;
            }

            foreach (Process processItem in processItems)
            {
                processItem.Kill();
            }
            Console.WriteLine($"{processItems.Length} \"{argName}\" killed.");
        }

    }
}