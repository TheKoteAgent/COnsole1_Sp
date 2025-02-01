using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_HW2
{

    internal class Program
    {
        public static void ShowSymbol(object param)
        {
            var threadParams = param as TestClass;
            if (threadParams == null) return;

            Console.WriteLine("Start работы метода с принимаемыми аргументами\n");

            for (int i = 0; i < threadParams.SymbolCount; i++)
            {
                Thread.Sleep(20);
                Console.Write(threadParams.Symbol.ToString());
            }

            Console.WriteLine("\nFinish работы метода с принимаемыми аргументами");
        }

        static void Main(string[] args)
        {
            Thread threadOne = new Thread(new ParameterizedThreadStart(ShowSymbol));
            Thread threadTwo = new Thread(new ParameterizedThreadStart(ShowSymbol));
            Thread threadThree = new Thread(new ParameterizedThreadStart(ShowSymbol));

            threadOne.Start(new TestClass { Symbol = '*', SymbolCount = 50 });
            threadTwo.Start(new TestClass { Symbol = '#', SymbolCount = 50 });
            threadThree.Start(new TestClass { Symbol = '@', SymbolCount = 50 });
        }   
    }
}