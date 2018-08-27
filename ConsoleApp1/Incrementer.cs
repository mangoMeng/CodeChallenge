using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class IncrementerEventArgs : EventArgs
    {
        public int IterationCount { get; set; }
    }



    class Incrementer
    {
        public event EventHandler<IncrementerEventArgs> CountedADozen;//创建事件

        public void DoCount()
        {
            IncrementerEventArgs args = new IncrementerEventArgs();

            for (int i = 0; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    args.IterationCount = i;
                    CountedADozen(this, args);
                }
            }
        }
    }

    class Dozens
    {
        public int DozensCount { get; set; }
        public Dozens(Incrementer incrementer)
        {
            incrementer.CountedADozen += Incrementer_CountedADozen;//订阅事件
        }

        private void Incrementer_CountedADozen(object source, IncrementerEventArgs e)//声明事件处理程序
        {
            Console.WriteLine("Incremented at iteration: {0} in {1}", e.IterationCount, source.ToString());
            DozensCount++;
        }
    }

    class ProgramDomain
    {
        static void Main()
        {
            Incrementer incrementer = new Incrementer();
            Dozens dozens = new Dozens(incrementer);
            incrementer.DoCount();
            Console.WriteLine(dozens.DozensCount);
            Console.ReadKey();
        }
    }
}
