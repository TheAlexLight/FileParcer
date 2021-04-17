using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TasksLibrary;

namespace _4.FileParcer.Interfaces.Factory
{
    public interface IParcerFactory
    {
        IFileManager CreateFileManager(string tempFilePath);
        IParcer CreateParcer(IFileManager manager, IOutsidePrinter printer);
        IReplacer CreateReplacer();
    }
}
