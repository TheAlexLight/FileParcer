using _4.FileParcer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class LineReplacer : IReplacer
    {
        public string ReplaceString(string line, string stringForSearching, string stringForReplacing)
        {
            string newLine = line;

            if (line.Contains(stringForSearching))
            {
                newLine = line.Replace(stringForSearching, stringForReplacing);
            }

            return newLine;
        }

    }
}
