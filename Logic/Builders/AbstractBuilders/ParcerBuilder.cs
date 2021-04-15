﻿using _4.FileParcer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Builders.AbstractBuilders
{
   abstract class ParcerBuilder
    {
       public abstract IParcer CreateParcer(IFileManager manager);
    }
}
