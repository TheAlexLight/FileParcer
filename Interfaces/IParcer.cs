using _4.FileParcer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer
{
    public interface IParcer
    {
        void Parce(IReplacer stringReplacer, string[] args);
        int CountOccurrences(string[] args);
    }
}
