using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        private int _maxCapacity;

        private List<InventoryItem> _items;

        public Basket()
        {
            _items = new List<InventoryItem>();
            _maxCapacity = 5;
        }

        public bool AddBagelToBasket(InventoryItem item)
        {

            if (_items.Count < _maxCapacity)
            {
                _items.Add(item);

                return true;
            }

            return false;
        }

        public bool RemoveBagel(InventoryItem item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                return true;
            }
            return false;

        }

        public List<InventoryItem> Bagels { get { return _items.Where(x => x.Name == "Bagel").ToList(); } }
        public int MaxCapacity
        {
            get
            {
                return _maxCapacity;
            }
            set
            {
                _maxCapacity = value;
                _items.Clear();

            }
        }
        public string BasketStatus()
        {
            return _items.Count == _maxCapacity ? "Basket Full" : "Basket Not Full";
        }
        public List<InventoryItem> Items
        {
            get { return _items; }
        }
    }
}
