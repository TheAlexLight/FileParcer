using _4.FileParcer.Interfaces.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer.Controllers
{
    class FullFactory
    {
        public FullFactory(IOutsidePrinterFactory printerFactory, IValidatorFactory validatorFactory, IParcerFactory parcerFactory)
        {
            _printerFactory = printerFactory;
            _validatorFactory = validatorFactory;
            _parcerFactory = parcerFactory;
        }

        readonly IOutsidePrinterFactory _printerFactory;
        readonly IValidatorFactory _validatorFactory;
        readonly IParcerFactory _parcerFactory;

        public IOutsidePrinterFactory PrinterFactory => _printerFactory;
        public IValidatorFactory ValidatorFactory => _validatorFactory;
        public IParcerFactory ParcerFactory => _parcerFactory;
    }
}
