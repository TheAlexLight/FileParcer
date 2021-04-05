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
        ConsolePrinter printer = new ConsolePrinter();
        Validator validData = new Validator();

        public void ExecuteMainOperations(string fileName, string stringForCount)
        {

        }

        public void ExecuteMainOperations(string fileName, string stringForSearching, string stringForReplacement)
        {

        }

        public string CheckStartString(string checkedString, string checkedStringName)
        {  
            if (!validData.CheckStringLength(checkedString))
            {
                printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedStringName));
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
                printer.WriteLine(string.Format(Constant.ENTER_PROMPT, checkedStringName));

                enteredString = printer.ReadLine();

                if (!validData.CheckStringLength(enteredString))
                {
                    printer.WriteLine(string.Format(Constant.WRONG_STRING, checkedStringName));
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
