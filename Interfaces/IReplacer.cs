using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces
{
    interface IReplacer
    {
        List<string> ReplaceStrings(List<string> listOfFileLines, string stringForSearching, string stringForReplacing);
    }
}
