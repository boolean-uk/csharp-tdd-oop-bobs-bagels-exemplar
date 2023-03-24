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

        private List<InventoryItem> _bagels;

        public Basket()
        {            
             _bagels = new List<InventoryItem>();
            _maxCapacity = 5;
        }

        public bool AddBagelToBasket(InventoryItem bagel)
        {
            
            if(_bagels.Count < _maxCapacity)
            {
                _bagels.Add(bagel);
                
                return true;
            }
            
            return false;
        }

        public bool RemoveBagel(InventoryItem bagel)
        {
            if(_bagels.Contains(bagel))
            {            
                _bagels.Remove(bagel);
                return true;
            }
            return false;
            
        }

        public List<InventoryItem> Bagels { get { return _bagels.Where(x => x.Name=="Bagel").ToList(); } }
        public int MaxCapacity 
        { 
            get 
            { 
                return _maxCapacity; 
            } 
            set 
            {                 
                _maxCapacity = value;
                _bagels.Clear();

            } 
        }
        public string BasketStatus()
        {
            return _bagels.Count == _maxCapacity ? "Basket Full" : "Basket Not Full";
        }

    }
}
