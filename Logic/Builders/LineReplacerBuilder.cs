using _4.FileParcer.Interfaces;
using _4.FileParcer.Logic.Builders.AbstractBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Builders
{
    class LineReplacerBuilder : ReplacerBuilder
    {
        public override IReplacer CreateReplacer()
        {
            return new LineReplacer();
        }
    }
}
