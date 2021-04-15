using _4.FileParcer.Interfaces;
using _4.FileParcer.Logic.Builders.AbstractBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Builders
{
    class FileParcerBuilder : ParcerBuilder
    {
        public override IParcer CreateParcer(IFileManager manager)
        {
            return new FileAnalyser(manager);
        }
    }
}
