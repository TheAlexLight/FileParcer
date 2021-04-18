using System;
using System.Collections.Generic;

namespace _4.FileParcer.Interfaces
{
    public interface IManager : IDisposable
    {
        IEnumerable<string> Read(string filePath);
        void WriteLine(string stringToWrite);
    } 
}
