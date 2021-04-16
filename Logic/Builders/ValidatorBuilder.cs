using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Builders
{
    class ValidatorBuilder : IValidatorFactory
    {
        public IValidator CreateValidator()
        {
            return new Validator();
        }
    }
}
