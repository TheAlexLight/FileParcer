﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using _4.FileParcer.Logic.Builders;
using _4.FileParcer.View;
using TasksLibrary;

namespace _4.FileParcer.Controller
{
    class FileParcerController
    {
        readonly IOutsidePrinterFactory _printerFactory = new ConsolePrinterBuider();
        readonly IValidatorFactory _validatorFactory = new ValidatorBuilder();

        public void Initialize(string[] args)
        {
            IOutsidePrinter printer = _printerFactory.CreateOusidePrinter();

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
                    Console.WriteLine(Constant.FILE_NOT_EXIST);
                    printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);

                    Environment.Exit(-1);
                }


                IParcerFactory parcerFactory = new FileParcerBuilder();

                IFileManager manager = parcerFactory.CreateFileManager();
                IParcer fileParcer = parcerFactory.CreateParcer(manager, printer);

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
                printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
            catch (NullReferenceException ex)
            {
                printer.WriteLine(string.Format(Constant.ERROR_OCCURED, ex.Message));
                throw;
            }
        }

        public string CheckStartString(string checkedString)
        {
            IValidator validator = _validatorFactory.CreateValidator();
            IOutsidePrinter printer = _printerFactory.CreateOusidePrinter();

            if (!validator.CheckStringLength(checkedString))
            {
                printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedString));
                printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);

                Environment.Exit(-1);
            }

            return checkedString;
        }
    }
}
