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
        public FileManager(string tempfilePath)
        {
            _writer = new StreamWriter(tempfilePath);
        }

         readonly StreamWriter _writer;

        public StreamWriter Writer => _writer;

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
