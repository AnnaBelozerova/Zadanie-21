using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Задание_21
{
    class Program
    {
        private static int n;
        private static int m;
        private static int[,] sad;
        static object locker = new object();
        
        static void Main(string[] args)
        {
            Console.Write("Введите длину участка: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину участка: ");
            m = Convert.ToInt32(Console.ReadLine());
            sad = new int[n, m];

            ThreadStart threadStart1 = new ThreadStart(sadovnik1);
            Thread thread1 = new Thread(threadStart1);

            ThreadStart threadStart2 = new ThreadStart(sadovnik2);
            Thread thread2 = new Thread(threadStart2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,4}", sad[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }
        static void sadovnik1()
        {
            Console.WriteLine("Садовник 1 начал работу.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (sad[i, j] == 0)
                        sad[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine("Садовник 1 закончил работу.");
        }
        static void sadovnik2()
        {
            Console.WriteLine("Садовник 2 начал работу.");
            for (int j = m - 1; j > 0; j--)
            {
                for (int i = n - 1; i > 0; i--)
                {
                    if (sad[i, j] == 0)
                        sad[i, j] = 2;
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine("Садовник 2 закончил работу.");
        }
    }
}
