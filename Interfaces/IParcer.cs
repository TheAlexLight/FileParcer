using _4.FileParcer.Interfaces;

namespace _4.FileParcer
{
    public interface IParcer
    {
        void Replace(IReplacer stringReplacer, string[] args);
        int CountOccurrences(string[] args);
    }
}
