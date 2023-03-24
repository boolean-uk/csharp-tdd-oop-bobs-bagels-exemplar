using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BobsBagelApp
    {
        private Inventory _inventory;
        public BobsBagelApp()
        {
            Initialize();
            Welcome();
            WriteMenu();
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome To Bobs Bagels App");
        }

        private void Initialize()
        {
            _inventory = new Inventory();
        }

        private void WriteMenu()
        {
            WriteSpacer();
            Console.WriteLine("Bagels");
            _inventory.GetBagels().ForEach(x => {
                Console.WriteLine($"{x.Variant} {x.Price.ToString("C")}");
            });
            WriteSpacer();
            Console.WriteLine("Fillings");
            _inventory.GetFillings().ForEach(x =>
            {
                Console.WriteLine($"{x.Variant} {x.Price.ToString("C")}");
            });
            WriteSpacer();
            Console.WriteLine("Coffees");
            _inventory.GetCoffees().ForEach(x =>
            {
                Console.WriteLine($"{x.Variant} {x.Price.ToString("C")}");
            });
            WriteSpacer();
        }
        private void WriteSpacer()
        {
            Console.WriteLine("----------------------------------------------");
        }
    }
}
