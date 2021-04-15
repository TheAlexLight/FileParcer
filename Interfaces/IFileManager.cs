using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces
{
    interface IFileManager 
    {
        IEnumerable<string> ReadFile(string filePath);
        void WriteLineToFile(string stringToWrite);
    }
}
