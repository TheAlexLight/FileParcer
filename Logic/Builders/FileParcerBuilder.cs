using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using TasksLibrary;

namespace _4.FileParcer.Logic.Builders
{
    class FileParcerBuilder : IParcerFactory
    {
        public IManager CreateFileManager(string tempFilePath)
        {
            return new FileManager(tempFilePath);
        }

        public IParcer CreateParcer(IParcerFactory managerFactory, IOutsidePrinter printer)
        {
            return new FileAnalyser(managerFactory, printer);
        }

        public IReplacer CreateReplacer()
        {
            return new LineReplacer();
        }
    }
}
