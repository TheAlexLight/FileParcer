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
            try
            {
                FileParcerController parcerController = new FileParcerController();

                if (args.Length == 2)
                {
                    parcerController.ExecuteSearchingOperations(args[0], args[1]);
                }
                else if (args.Length == 3)
                {
                    parcerController.ExecuteSearchingOperations(args[0], args[1]);
                }
                else
                {
                    throw new ArgumentException();
                }

                Console.ReadKey();
            }
            catch (Exception)
            {

                throw;
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
