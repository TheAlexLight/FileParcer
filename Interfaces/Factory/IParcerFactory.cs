using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces.Factory
{
    interface IParcerFactory
    {
        IFileManager CreateFileManager();
        IParcer CreateParcer(IFileManager manager);
        IReplacer CreateReplacer();
    }
}
