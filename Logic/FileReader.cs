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
    class FileReader
    {
        public FileReader(string fileName)
        {
            _fileName = fileName;
        }

        private readonly string _fileName;

        public IEnumerator GetEnumerator()
        {
            using (StreamReader reader = new StreamReader(_fileName))
            {
                while (reader.Peek() != -1)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
