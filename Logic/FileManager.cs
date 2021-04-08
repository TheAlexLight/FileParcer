using _4.FileParcer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class FileManager : IFileManager
    {
        public List<string> ReadLine(string filePath, ref int skipLinesNumber, ref bool isEndOfFile)
        {
            int maxBufferSize = 50000;

            List<string> readLinesList = new List<string>();

            readLinesList.AddRange(File.ReadLines(filePath).Skip(skipLinesNumber).Take(maxBufferSize));

            if (readLinesList.Count == maxBufferSize)
            {
                skipLinesNumber += maxBufferSize; 
            }
            else
            {
                isEndOfFile = true;
            }

            return readLinesList;
        }

        public void AppendLines(List<string> listOfLines,string filePath)
        {
            File.AppendAllLines(filePath, listOfLines);
        }
    }
}
