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

        public void ShowInstruction(params string[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
            }
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
