﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Interfaces
{
    interface IReplacer
    {
        string ReplaceString(string line, string stringForSearching, string stringForReplacing);
    }
}
