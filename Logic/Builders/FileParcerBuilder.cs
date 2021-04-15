using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Builders
{
    class FileParcerBuilder : IParcerFactory
    {
        public IFileManager CreateFileManager()
        {
            return new FileManager();
        }

        public IParcer CreateParcer(IFileManager manager)
        {
            return new FileAnalyser(manager);
        }

        public IReplacer CreateReplacer()
        {
            return new LineReplacer();
        }
    }
}
