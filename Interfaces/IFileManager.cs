using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces
{
    public interface IFileManager : IDisposable
    {
        IEnumerable<string> ReadFile(string filePath);
        void WriteLineToFile(string stringToWrite);
        StreamWriter OpenFileForWrite(string fileName);
    } 
}
