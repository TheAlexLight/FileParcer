using TasksLibrary;

namespace _4.FileParcer.Interfaces.Factory
{
    public interface IParcerFactory
    {
        IManager CreateFileManager(string tempFilePath);
        IParcer CreateParcer(IParcerFactory managerFactory, IOutsidePrinter printer);
        IReplacer CreateReplacer();
    }
}
