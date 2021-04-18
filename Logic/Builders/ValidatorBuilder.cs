using _4.FileParcer.Interfaces;
using _4.FileParcer.Interfaces.Factory;

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
