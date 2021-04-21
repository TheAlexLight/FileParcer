using _4.FileParcer.Controllers;
using _4.FileParcer.Interfaces.Factory;

namespace _4.FileParcer.Logic.Abstract
{
    public abstract class Controller
    {
       readonly protected FullFactory _allFactories;

        public Controller(FullFactory allFactories)
        {
            _allFactories = allFactories;
        }

        public abstract void Initialize(string[] args);
        public abstract string CheckStartString(string checkedString);
    }
}
