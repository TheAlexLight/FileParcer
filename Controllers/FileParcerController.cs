using System;
using _4.FileParcer.Enums;
using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using _4.FileParcer.Logic.Abstract;
using _4.FileParcer.View;
using TasksLibrary;

namespace _4.FileParcer.Controllers
{
    class FileParcerController : Controller
    {
        public FileParcerController(IOutsidePrinterFactory printerFactory, IValidatorFactory validatorFactory, IParcerFactory parcerFactory) 
            : base(printerFactory,validatorFactory, parcerFactory)
        {
        }

        public override void Initialize(string[] args)
        {
            IOutsidePrinter printer = _printerFactory.CreateOutsidePrinter();

            try
            {
                string[] checkedArgs = new string[args.Length];

                for (int i = 0; i < checkedArgs.Length; i++)
                {
                    checkedArgs[i] = CheckStartString(args[i]);
                }

                IValidator validator = _validatorFactory.CreateValidator();
               

                if (!validator.CheckFilePath(checkedArgs[0]))
                {
                    printer.WriteLine(string.Format(Constant.ERROR_OCCURED, Constant.FILE_NOT_EXIST), (int)Color.Red);
                    printer.ShowInstruction();
                    Environment.Exit(-1);
                }

                IParcer fileParcer = _parcerFactory.CreateParcer(_parcerFactory, printer);

                int count;

                if (args.Length == 2)
                {
                    count = fileParcer.CountOccurrences(checkedArgs);
                    printer.WriteLine(string.Format(Constant.AMOUNT_OF_OCURRENSES,count), (int)Color.Red);
                }
                else
                {
                    fileParcer.Parce(_parcerFactory.CreateReplacer(), checkedArgs);
                    printer.WriteLine(Constant.SUCCESS, (int)Color.Green);
                }

            }
            catch (ArgumentException ex)
            {
                printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
            catch (NullReferenceException ex)
            {
                printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message), (int)Color.Red);
                throw;
            }
        }

        public override string CheckStartString(string checkedString)
        {
            IValidator validator = _validatorFactory.CreateValidator();
            IOutsidePrinter printer = _printerFactory.CreateOutsidePrinter();

            if (!validator.CheckStringLength(checkedString))
            {
                printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedString), (int)Color.Red);
                printer.ShowInstruction();

                Environment.Exit(-1);
            }

            return checkedString;
        }
    }
}
