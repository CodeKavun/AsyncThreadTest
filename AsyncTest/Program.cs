using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Mutex.OpenExisting("GOAT");
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                Console.WriteLine("This process is the only spicement in this OS!");
            }

            Console.ReadKey();
        }
    }
}
