using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IConsoleA
    {
        void WriteSomething(string msg);
    }

    public interface IConsoleB
    {
        void WriteSomething(string msg);
    }

    public class ConsoleCC : IConsoleA, IConsoleB
    {
        public void WriteSomething(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class MainClass
    {
        static void Main()
        {
            ConsoleCC cC = new ConsoleCC();
            cC.WriteSomething("Hello from ConsoleCC");
            IConsoleA IA = cC as IConsoleA;
            IConsoleB IB = cC as IConsoleB;
            IA.WriteSomething("Hello from IConsoleA");
            IB.WriteSomething("Hello from IConsoleB");
            Console.ReadKey();
        }
    }

}
