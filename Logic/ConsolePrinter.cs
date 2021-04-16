using _4.FileParcer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TasksLibrary;

namespace _4.FileParcer.Logic
{
    internal class ConsolePrinter : IOutsidePrinter
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void ShowInstruction()
        {
            Console.WriteLine(Constant.INSTRUCTION);
            Console.WriteLine(Constant.COUNT_MODE);
            Console.WriteLine(Constant.FIRST_ARGUMENT_COUNT_MODE);
            Console.WriteLine(Constant.SECOND_ARGUMENT_COUNT_MODE);
            Console.WriteLine(Constant.REPLACING_MODE);
            Console.WriteLine(Constant.FIRST_ARGUMENT_REPLACING_MODE);
            Console.WriteLine(Constant.SECOND_ARGUMENT_REPLACING_MODE);
            Console.WriteLine(Constant.THIRD_ARGUMENT_REPLACING_MODE);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
