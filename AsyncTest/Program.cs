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
            // 1
            List<int> ints = new List<int> { 2, 5, 2, 123, 56, 99, 34, 11, 44 };

            int indexAvgStart = 0;
            for (int i = 0; i < ints.Count / 3; i++)
            {
                List<int> intsPart = new List<int>();
                for (int j = 0; j < ints.Count / 3; j++)
                {
                    intsPart.Add(ints[indexAvgStart + j]);
                }
                indexAvgStart += ints.Count / 3;

                ThreadPool.QueueUserWorkItem(DisplayAvg, intsPart);
            }

            ThreadPool.QueueUserWorkItem(DisplayAvg, ints);

            Console.ReadKey();

            // 2
            int indexMaxStart = 0;
            for (int i = 0; i < ints.Count / 3; i++)
            {
                List<int> intsPart = new List<int>();
                for (int j = 0; j < ints.Count / 3; j++)
                {
                    intsPart.Add(ints[indexMaxStart + j]);
                }
                indexMaxStart += ints.Count / 3;

                ThreadPool.QueueUserWorkItem(DisplayMax, intsPart);
            }

            ThreadPool.QueueUserWorkItem(DisplayMax, ints);

            Console.ReadKey();

            // 3
            List<string> strings = new List<string> { "Python", "C# is cool", "C++ is awful", "MonoGame", "XNA", "JS" };

            int indexRevStrStart = 0;
            for (int i = 0; i < strings.Count / 2; i++)
            {
                for (int j = 0; j < strings.Count / 3; j++)
                {
                    ThreadPool.QueueUserWorkItem(DisplayReversedString, strings[indexRevStrStart + j]);
                }
                indexRevStrStart += strings.Count / 3;
            }

            Console.ReadKey();

            // 4
            int indexStrContainsStart = 0;
            for (int i = 0; i < strings.Count / 2; i++)
            {
                for (int j = 0; j < strings.Count / 3; j++)
                {
                    ThreadPool.QueueUserWorkItem(DisplayIsStringContains, strings[indexStrContainsStart + j]);
                }
                indexStrContainsStart += strings.Count / 3;
            }

            Console.ReadKey();

            // 5
            int indexConcatStart = 0;
            for (int i = 0; i < strings.Count / 2; i++)
            {
                List<string> strPart = new List<string>();
                for (int j = 0; j < strings.Count / 3; j++)
                {
                    strPart.Add(strings[indexConcatStart + j]);
                }
                indexMaxStart += strings.Count / 3;

                ThreadPool.QueueUserWorkItem(DisplayConcatenation, strPart);
            }

            ThreadPool.QueueUserWorkItem(DisplayConcatenation, strings);

            Console.ReadKey();
        }

        static void DisplayAvg(object state)
        {
            Console.WriteLine("<Average> Thread ID: " + Thread.CurrentThread.ManagedThreadId
                + " - " + (state as List<int>).Average());
            Thread.Sleep(500);
        }

        static void DisplayMax(object state)
        {
            Console.WriteLine("<Maximum> Thread ID: " + Thread.CurrentThread.ManagedThreadId
                + " - " + (state as List<int>).Max());
            Thread.Sleep(500);
        }

        static void DisplayReversedString(object state)
        {
            char[] chars = (state as string).ToCharArray();
            Array.Reverse(chars);

            string reversedString = new string(chars);

            Console.WriteLine("<StringReversed> Thread ID: " + Thread.CurrentThread.ManagedThreadId
                + " - " + reversedString);
            Thread.Sleep(500);
        }

        static void DisplayIsStringContains(object state)
        {
            Console.WriteLine("<IsStringContsins> Thread ID: " + Thread.CurrentThread.ManagedThreadId
                + " - " + (state as string).Contains("is"));
            Thread.Sleep(500);
        }

        static void DisplayConcatenation(object state)
        {
            string concatenatedString = "";
            foreach (string str in (List<string>)state) concatenatedString += str;

            Console.WriteLine("<Concat> Thread ID: " + Thread.CurrentThread.ManagedThreadId
                + " - " + concatenatedString);
            Thread.Sleep(500);
        }
    }
}
