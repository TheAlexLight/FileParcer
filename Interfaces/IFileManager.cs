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
        IEnumerable<string> Read(string filePath);
        void WriteLine(string stringToWrite);
    } 
}
