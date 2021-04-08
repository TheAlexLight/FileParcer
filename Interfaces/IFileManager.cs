using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces
{
    interface IFileManager
    {
        List<string> ReadLine(string filePath, ref int skipLines, ref bool isEndOfFile);
        void AppendLines(List<string> listOfLines, string filePath);
    }
}
