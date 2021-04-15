using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using _4.FileParcer.Logic.Builders;
using _4.FileParcer.View;
using ConsoleTaskLibrary;

namespace _4.FileParcer.Controller
{
    class FileParcerController
    {
        private readonly ConsolePrinter _printer = new ConsolePrinter();
        private readonly Validator _validData = new Validator();

        public void Initialize(string[] args)
        {
            try
            {
                string[] checkedArgs = new string[args.Length];

                for (int i = 0; i < checkedArgs.Length; i++)
                {
                    checkedArgs[i] = CheckStartString(args[i]);
                }

                if (!_validData.CheckFilePath(checkedArgs[0]))
                {
                    Console.WriteLine(Constant.FILE_NOT_EXIST);
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);

                    Environment.Exit(-1);
                }


                IParcerFactory parcerFactory = new FileParcerBuilder();

                IFileManager manager = parcerFactory.CreateFileManager();
                IParcer fileParcer = parcerFactory.CreateParcer(manager);

                int count;

                if (args.Length == 2)
                {
                    count = fileParcer.CountOccurrences(checkedArgs);
                }
                else
                {
                    fileParcer.Parce(parcerFactory.CreateReplacer(), checkedArgs);
                }
            }
            catch (ArgumentException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            catch (NullReferenceException ex)
            {
                _printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
        }

        public string CheckStartString(string checkedString)
        {
            if (!_validData.CheckStringLength(checkedString))
            {
                _printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedString));
                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);

                Environment.Exit(-1);
            }

            return checkedString;
        }
    }
}
