using _4.FileParcer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class Replacer: IReplacer
    {
        public List<string> ReplaceStrings(List<string> listOfFileLines, string stringForSearching, string stringForReplacing)
        {
            List<string> newLinesString = new List<string>();

            foreach (var line in listOfFileLines)
            {
                if (line.Contains(stringForSearching))
                {
                    newLinesString.Add(line.Replace(stringForSearching, stringForReplacing));
                }
                else
                {
                    newLinesString.Add(line);
                }
            }

            return newLinesString;
        }

    }
}
