using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Inventory
    {
        private List<InventoryItem> _inventoryItems;

        public Inventory()
        {
            _inventoryItems =  new List<InventoryItem>()
            {
                new InventoryItem() { SKU = "BGLO", Price = 0.49f, Name = "Bagel", Variant = "Onion" },
                new InventoryItem() { SKU = "BGLP", Price = 0.39f, Name = "Bagel", Variant = "Plain" },
                new InventoryItem() { SKU = "BGLE", Price = 0.49f, Name = "Bagel", Variant = "Everything" },
                new InventoryItem() { SKU = "BGLS", Price = 0.49f, Name = "Bagel", Variant = "Sesame" },
                new InventoryItem() { SKU = "COFB", Price = 0.99f, Name = "Coffee", Variant = "Black" },
                new InventoryItem() { SKU = "COFW", Price = 1.19f, Name = "Coffee", Variant = "White" },
                new InventoryItem() { SKU = "COFC", Price = 1.29f, Name = "Coffee", Variant = "Capuccino" },
                new InventoryItem() { SKU = "COFL", Price = 1.29f, Name = "Coffee", Variant = "Latte" },
                new InventoryItem() { SKU = "FILB", Price = 0.12f, Name = "Filling", Variant = "Bacon" },
                new InventoryItem() { SKU = "FILE", Price = 0.12f, Name = "Filling", Variant = "Egg" },
                new InventoryItem() { SKU = "FILC", Price = 0.12f, Name = "Filling", Variant = "Cheese" },
                new InventoryItem() { SKU = "FILX", Price = 0.12f, Name = "Filling", Variant = "Cream Cheese" },
                new InventoryItem() { SKU = "FILS", Price = 0.12f, Name = "Filling", Variant = "Smoked Salmon" },
                new InventoryItem() { SKU = "FILH", Price = 0.12f, Name = "Filling", Variant = "Ham" }
            };
        }
        public List<InventoryItem> GetBagels()
        {
            return _inventoryItems.Where(x => x.Name=="Bagel").ToList();
        }
        public List<InventoryItem> GetFillings()
        {
            return _inventoryItems.Where(x => x.Name == "Filling").ToList();
        }
        public List<InventoryItem> GetCoffees()
        {
            return _inventoryItems.Where(x => x.Name == "Coffee").ToList();
        }
    }
}
