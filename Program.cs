using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _4.FileParcer.Controllers;
using _4.FileParcer.Logic;
using _4.FileParcer.Logic.Abstract;
using _4.FileParcer.View;

namespace _4.FileParcer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Controller parcerController = new FileParcerController();

                if (args.Length == 2 || args.Length == 3)
                {
                    parcerController.Initialize(args);
                }
                else
                {
                    throw new ArgumentException();
                }

                Console.ReadKey();
            }
            catch (Exception )
            {
                ConsolePrinter _printer = new ConsolePrinter();
                _printer.ShowInstruction();
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
}
