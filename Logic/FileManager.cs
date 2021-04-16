using _4.FileParcer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    internal class FileManager : IFileManager
    {
        StreamWriter _writer;

        public IEnumerable<string> ReadFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() != -1)
                {
                    yield return reader.ReadLine();
                }
            }
        }

        public StreamWriter OpenFileForWrite(string fileName)
        {
            return _writer = new StreamWriter(fileName);
        }

        public void WriteLineToFile(string line)
        {
            _writer.WriteLine(line);
        }

        public void Dispose()
        {
            if (_writer != null)
            {
                _writer.Dispose();
            }
        }
    }
}
