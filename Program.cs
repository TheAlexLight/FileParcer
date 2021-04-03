using _4.FileParcer.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.FileParcer
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler fileUser = new FileHandler();

            fileUser.OpenOrCreate().GetAwaiter().GetResult();
            Console.ReadKey();
        }
    }
}
