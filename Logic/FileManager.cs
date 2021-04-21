using System.Collections.Generic;
using System.IO;

using _4.FileParcer.Interfaces;

namespace _4.FileParcer.Logic
{
    internal class FileManager : IManager
    {
        public FileManager(string tempfilePath)
        {
            if (tempfilePath != null)
            {
                _writer = new StreamWriter(tempfilePath);
            }
        }

         readonly StreamWriter _writer;

        public IEnumerable<string> Read(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() != -1)
                {
                    yield return reader.ReadLine();
                }
            }
        }

        public void WriteLine(string line)
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
