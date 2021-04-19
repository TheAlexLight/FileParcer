using System;

using _4.FileParcer.Controllers;
using _4.FileParcer.Logic.Abstract;
using _4.FileParcer.Logic.Builders;
using TasksLibrary;

namespace _4.FileParcer
{
    class Program
    {
        static void Main(string[] args)
        {
            FullFactory allFactories = new FullFactory(new ConsolePrinterBuider(), new ValidatorBuilder(), new FileParcerBuilder());

            try
            {
                Controller parcerController = new FileParcerController(allFactories.PrinterFactory, allFactories.ValidatorFactory, allFactories.ParcerFactory);

                if (args.Length == 2 || args.Length == 3)
                {
                    parcerController.Initialize(args);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception )
            {
                IOutsidePrinter _printer = allFactories.PrinterFactory.CreateOutsidePrinter(); 
                _printer.ShowInstruction();
            }
        }
    }
}
