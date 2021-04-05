using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer
{
     class Validator
    {
        public bool CheckStringLength(string checkedString)
        {
            bool result = false;

            if (!(checkedString == null || checkedString.Length <= 0))
            {
                result = true;
            }

            return result;
        }
    }
}
