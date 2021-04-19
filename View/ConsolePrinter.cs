using _4.FileParcer.Enums;
using System;

using TasksLibrary;

namespace _4.FileParcer.View
{
    internal class ConsolePrinter : IOutsidePrinter
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void ShowInstruction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(Constant.INSTRUCTION);
            Console.WriteLine(Constant.COUNT_MODE);
            Console.ResetColor();
            Console.WriteLine(Constant.FIRST_ARGUMENT_COUNT_MODE);
            Console.WriteLine(Constant.SECOND_ARGUMENT_COUNT_MODE);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Constant.REPLACING_MODE);
            Console.ResetColor();
            Console.WriteLine(Constant.FIRST_ARGUMENT_REPLACING_MODE);
            Console.WriteLine(Constant.SECOND_ARGUMENT_REPLACING_MODE);
            Console.WriteLine(Constant.THIRD_ARGUMENT_REPLACING_MODE);

            Console.ResetColor();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message, int color)
        {
            switch (color)
            {
                case (int)Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case (int)Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case (int)Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
