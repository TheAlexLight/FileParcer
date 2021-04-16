using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Abstract
{
    public abstract class Controller
    {
        public abstract void Initialize(string[] args);
        public abstract string CheckStartString(string checkedString);
    }
}
