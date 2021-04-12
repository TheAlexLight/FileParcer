using _4.FileParcer.Controller;
using _4.FileParcer.Logic;
using _4.FileParcer.View;
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
            try
            {
                FileParcerController parcerController = new FileParcerController();

                if (args.Length == 2)
                {
                    parcerController.ExecuteSearchingOperations(args[0], args[1]);
                }
                else if (args.Length == 3)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    parcerController.ExecuteReplacingOperations(args[0], args[1],args[2]);
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.ElapsedMilliseconds); 
                }
                else
                {
                    throw new ArgumentException();
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ConsolePrinter _printer = new ConsolePrinter();
                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);
            }
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
