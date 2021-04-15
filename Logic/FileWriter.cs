using _4.FileParcer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class FileWriter : IFileWriter
    {
        private StreamWriter writer;

        public StreamWriter OpenFile(string fileName)
        {
            return writer = new StreamWriter(fileName);
        }

        public void WriteLine(string line)
        {
            writer.WriteLine(line);
        }

        public void Dispose()
        {
            if (writer != null)
            {
                writer.Dispose();
            }
        }
    }
}
