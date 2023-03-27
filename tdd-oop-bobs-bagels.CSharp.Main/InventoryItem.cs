using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class InventoryItem
    {
		private string _sku;
		private double _price;
		private string _name;
		private string _variant;



		public string SKU { get => _sku; set => _sku = value; }				
        public double Price { get => _price; set => _price = value; }
		public string Name { get => _name; set => _name = value; }
		public string Variant { get => _variant; set => _variant = value; }

		public string ItemDetails => $"{_sku}|{_variant}|{_price.ToString("C")}";

    }
}
