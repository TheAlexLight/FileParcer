using _4.FileParcer.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            // Запускаем внутренний таймер объекта Stopwatch
            
            FileAnalyser fileUser = new FileAnalyser();
            
            stopwatch.Start();
            //int count = fileUser.CountOccurrencesInFile("file2.txt", "ABCDEFG");
            int count = fileUser.ParceFile("file.txt", "ABCDEFG", "QWERTYVCX");
            stopwatch.Stop();

            //IncreaseSize();
            Console.WriteLine("Потрачено миллисекунд на выполнение: " + stopwatch.ElapsedMilliseconds);
            //Console.WriteLine("Количество вхождений: " + count);
            //Console.WriteLine("Потреблено памяти: " + consumedInMegabytes);
            Console.WriteLine("Количество замен: " + count);

            

            Console.ReadKey();
        }

        public static void IncreaseFileSize()
        {
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string[] array;

                array = File.ReadAllLines("file.txt");

                File.AppendAllLines("file2.txt", array);
            }
        }
    }
}
