using _4.FileParcer.Interfaces.Factory;

namespace _4.FileParcer.Controllers
{
    public class FullFactory
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
