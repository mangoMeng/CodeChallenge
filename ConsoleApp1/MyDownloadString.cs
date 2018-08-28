using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MainRun
    {
        static void Main()
        {
            MyDownloadString myDownload = new MyDownloadString();
            myDownload.DoRun();
        }
    }

    public class MyDownloadString
    {
        Stopwatch sw = new Stopwatch();
        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();
            Task<int> t1 = CountCharactersAsync(1, "http://www.microsoft.com");
            Task<int> t2 = CountCharactersAsync(2, "http://www.illustratedcsharp.com");
            CountToALargeNumber(1, LargeNumber);
            CountToALargeNumber(2, LargeNumber);
            CountToALargeNumber(3, LargeNumber);
            CountToALargeNumber(4, LargeNumber);
            Console.WriteLine("Chars in http://www.microsoft.coin  :{0}", t1);
            Console.WriteLine("Chars in http://www.illustratedcsharp.com: {0}", t2);
        }

        private async Task<int> CountCharactersAsync(int id, string uriString)
        {
            WebClient wc1 = new WebClient();
            Console.WriteLine("Starting call {0}     :    {1, 4:N} ms", id, sw.Elapsed.Milliseconds);
            string result = await wc1.DownloadStringTaskAsync(new Uri(uriString));
            Console.WriteLine("    Call {0} completed:    {1, 4:N} ms", id, sw.Elapsed.Milliseconds);
            return result.Length;
        }

        private void CountToALargeNumber(int id, int value)
        {
            for (long i = 0; i < value; i++)
                ;
            Console.WriteLine("    End counting {0}  :    {1,4:N} ms", id, sw.Elapsed.Milliseconds);
        }
    }
}
