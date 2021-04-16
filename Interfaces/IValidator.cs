using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces
{
    interface IValidator
    {
        bool CheckStringLength(string checkedString);
        bool CheckFilePath(string fileName);
    }
}
