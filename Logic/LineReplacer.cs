using _4.FileParcer.Interfaces;

namespace _4.FileParcer.Logic
{
    internal class LineReplacer : IReplacer
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
