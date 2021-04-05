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

        public void ExecuteMainOperations(string fileName, string stringForCount)
        {
            fileName = CheckStartString(fileName, Constant.FILE_NAME);
            stringForCount = CheckStartString(stringForCount, Constant.STRING_FOR_COUNT);

            FileAnalyser _fileUser = new FileAnalyser();

           int countOcurrences = _fileUser.CountOccurrencesInFile(fileName, stringForCount);

            ConsolePrinter _printer = new ConsolePrinter();

            _printer.WriteLine(string.Format(Constant.AMOUNT_OF_OCURRENSES, countOcurrences));
        }

        public void ExecuteMainOperations(string fileName, string stringForSearching, string stringForReplacing)
        {
            fileName = CheckStartString(fileName, Constant.FILE_NAME);
            stringForSearching = CheckStartString(stringForSearching, Constant.STRING_FOR_COUNT);
            stringForReplacing = CheckStartString(stringForReplacing, Constant.STRING_FOR_COUNT);

            FileAnalyser _fileUser = new FileAnalyser();

            int countReplaces = _fileUser.ParceFile(fileName, stringForSearching, stringForReplacing);

            ConsolePrinter _printer = new ConsolePrinter();

            _printer.WriteLine(string.Format(Constant.AMOUNT_OF_REPLACES, countReplaces));
        }

        public string CheckStartString(string checkedString, string checkedStringName)
        {  
            if (!_validData.CheckStringLength(checkedString))
            {
                _printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedStringName));
                checkedString = EnterNewString(checkedStringName); 
            }

            return checkedString;
        }

        private string EnterNewString(string checkedStringName)
        {
            string enteredString = "";
            bool rightFormat = false;

            while(!rightFormat)
            {
                _printer.WriteLine(string.Format(Constant.ENTER_PROMPT, checkedStringName));

                enteredString = _printer.ReadLine();

                if (!_validData.CheckStringLength(enteredString))
                {
                    _printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedStringName));
                }
                else
                {
                    rightFormat = true;
                }
            }

            return enteredString;
        }
    }
}
