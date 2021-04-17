using _4.FileParcer.Interfaces.Factory;
using _4.FileParcer.Logic.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Logic.Abstract
{
    public abstract class Controller
    {
        protected readonly IOutsidePrinterFactory _printerFactory;
        protected readonly IValidatorFactory _validatorFactory;
        protected readonly IParcerFactory _parcerFactory;

        public Controller(IOutsidePrinterFactory printerFactory, IValidatorFactory validatorFactory, IParcerFactory parcerFactory)
        {
            _printerFactory = printerFactory;
            _validatorFactory = validatorFactory;
            _parcerFactory = parcerFactory;
        }

        public abstract void Initialize(string[] args);
        public abstract string CheckStartString(string checkedString);
    }
}
