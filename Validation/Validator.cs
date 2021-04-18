using System.IO;

using _4.FileParcer.Interfaces;
using _4.FileParcer.View;

namespace _4.FileParcer
{
    class Validator : IValidator
    {
        public bool CheckStringLength(string checkedString)
        {
            bool result = false;

            if (!(checkedString == null || checkedString.Length <= 0 || checkedString.Length > Constant.MAX_STRING_LENGTH))
            {
                result = true;
            }

            return result;
        }

        public bool CheckFilePath(string fileName)
        {
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), fileName));
        }
    }
}
