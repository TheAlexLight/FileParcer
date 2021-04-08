using _4.FileParcer.Logic;
using _4.FileParcer.View;
using ConsoleTaskLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Controller
{
    class FileParcerController
    {
        private readonly ConsolePrinter _printer = new ConsolePrinter();
        private readonly Validator _validData = new Validator();

        public void ExecuteSearchingOperations(string fileName, string stringForCount)
        {
            try
            {
                fileName = CheckStartString(fileName, Constant.FILE_NAME);

                if (!_validData.CheckFilePath(fileName))
                {
                    Console.WriteLine(Constant.FILE_NOT_EXIST);
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);
                    
                    Environment.Exit(-1);
                }

                stringForCount = CheckStartString(stringForCount, Constant.STRING_FOR_COUNT);

                FileAnalyser _fileUser = new FileAnalyser();

                int countOcurrences = _fileUser.CountOccurrences(fileName, stringForCount);

                _printer.WriteLine(string.Format(Constant.AMOUNT_OF_OCURRENSES, countOcurrences));
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

        public void ExecuteReplacingOperations(string fileName, string stringForSearching, string stringForReplacing)
        {
            try
            {
                fileName = CheckStartString(fileName, Constant.FILE_NAME);

                if (!_validData.CheckFilePath(fileName))
                {
                    Console.WriteLine(Constant.FILE_NOT_EXIST);
                    _printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);
                   
                    Environment.Exit(-1);
                }

                stringForSearching = CheckStartString(stringForSearching, Constant.STRING_FOR_COUNT);
                stringForReplacing = CheckStartString(stringForReplacing, Constant.STRING_FOR_REPLACING);

                FileAnalyser _fileUser = new FileAnalyser();

                 _fileUser.Parce(fileName, stringForSearching, stringForReplacing);

                _printer.WriteLine(Constant.SUCCESS);
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

        public string CheckStartString(string checkedString, string checkedStringName)
        {
            if (!_validData.CheckStringLength(checkedString))
            {
                _printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedStringName));
                _printer.ShowInstruction(Constant.INSTRUCTION, Constant.COUNT_MODE, Constant.FIRST_ARGUMENT_COUNT_MODE, Constant.SECOND_ARGUMENT_COUNT_MODE,
                        Constant.REPLACING_MODE, Constant.FIRST_ARGUMENT_REPLACING_MODE, Constant.SECOND_ARGUMENT_REPLACING_MODE, Constant.THIRD_ARGUMENT_REPLACING_MODE);

                Environment.Exit(-1);
            }

            return checkedString;
        }
    }
}
