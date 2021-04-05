using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer
{
    interface IParcer
    {
        int ParceFile(string fileName, string searchInFile, string replaceInFile);
        int CountOccurrencesInFile(string fileName, string searchInFile);
    }
}
