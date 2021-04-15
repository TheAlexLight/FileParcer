using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic
{
    class FileParcerDialog : ParcerDialog
    {
        public override IParcer CreateParcer()
        {
            return new FileAnalyser();
        }
    }
}
