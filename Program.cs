using _4.FileParcer.Controller;
using _4.FileParcer.Logic;
using ConsoleTaskLibrary;
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
            FileParcerController parcerController = new FileParcerController();

            FileAnalyser fileUser = new FileAnalyser();
            
            //int count = fileUser.CountOccurrencesInFile("file.txt", "ABCDEFG");
            int count = fileUser.ParceFile("file.txt", "ABCDEFG", "QWERTYVCX");

            ConsolePrinter printer = new ConsolePrinter();

            printer.WriteLine("Amount ... = " + count);

            //Console.WriteLine("Количество вхождений: " + count);
            //Console.WriteLine("Количество замен: " + count);

            

            Console.ReadKey();
        }

        #region IncreaseFileSize
        //public static void IncreaseFileSize()
        //{
        //    using (StreamReader sr = new StreamReader("file.txt"))
        //    {
        //        string[] array;

        //        array = File.ReadAllLines("file.txt");

        //        File.AppendAllLines("file2.txt", array);
        //    }
        //}

        #endregion
    }
}
