namespace _4.FileParcer.Interfaces
{
    public interface IValidator
    {
        bool CheckStringLength(string checkedString);
        bool CheckFilePath(string fileName);
    }
}
