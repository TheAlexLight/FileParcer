using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _4.FileParcer.Interfaces.Factory;
using _4.FileParcer.View;
using TasksLibrary;

namespace _4.FileParcer.Logic.Builders
{
    class ConsolePrinterBuider : IOutsidePrinterFactory
    {
        public IOutsidePrinter CreateOutsidePrinter()
        {
            return new ConsolePrinter();
        }
    }
}
