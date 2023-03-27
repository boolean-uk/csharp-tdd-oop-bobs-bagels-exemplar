using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using tdd_bobs_bagels.CSharp.Main;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_bobs_bagels.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;
        private Inventory _invetory;

        public CoreTests()
        {
            _core = new Core();
            _invetory = new Inventory();
        }

       
        [Test]
        public void AddBagelAndCheckBasketForIt()
        {
            //q1
            InventoryItem bagel = _invetory.GetBagels().Where(x => x.SKU == "BGLO").First();

            Basket basket = new Basket();

            Assert.IsTrue(basket.AddBagelToBasket(bagel));

            Assert.IsTrue(basket.Bagels.Contains(bagel));
        }

        [Test]
        public void RemoveBagelAndCheckItsGone()
        {
            //q2
            InventoryItem bagel = _invetory.GetBagels().Where(x => x.SKU == "BGLO").First();

            Basket basket = new Basket();

            Assert.IsTrue(basket.AddBagelToBasket(bagel));

            Assert.IsTrue(basket.Bagels.Contains(bagel));

            Assert.IsTrue(basket.RemoveBagel(bagel));

            Assert.IsFalse(basket.Bagels.Contains(bagel));
        }
        [Test]
        public void CheckForBasketOverfill()
        {
            //q3
            Basket basket = new Basket();
            basket.MaxCapacity = _invetory.GetInventoryItemByName("Bagel").Count;
            Assert.IsTrue(basket.MaxCapacity > 0);

            foreach(InventoryItem b in _invetory.GetInventoryItemByName("Bagel"))
            {
                basket.AddBagelToBasket(b);
            }

            //check basket is at maximum capacity
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);

            //check we cant add another bagel
            Assert.IsFalse(basket.AddBagelToBasket(_invetory.GetBagels().Where(x => x.SKU == "BGLO").First()));

        }
        [Test]  
        public void CheckYouCanChangeBasketOverfill()
        {
            //q4
            Basket basket = new Basket();
            basket.MaxCapacity =_invetory.GetInventoryItemByName("Bagel").Count;

            foreach (InventoryItem b in _invetory.GetInventoryItemByName("Bagel"))
            {
                basket.AddBagelToBasket(b);
            }
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);
        }
        [Test]
        public void BasketEmptiesWhenMaxCapacityChanges()
        {

            Basket basket = new Basket();
            basket.MaxCapacity = _invetory.GetInventoryItemByName("Bagel").Count;

            foreach (InventoryItem b in _invetory.GetInventoryItemByName("Bagel").ToList())
            {
                basket.AddBagelToBasket(b);
            }
            Assert.IsTrue(basket.Bagels.Count == basket.MaxCapacity);

            basket.MaxCapacity = 3;
            Assert.IsTrue(basket.Bagels.Count == 0);
        }
        [Test]
        public void TryAndRemoveAnItemThatDoesntExist()
        {
            //q5
            Basket basket = new Basket();
            basket.MaxCapacity = 20;

            foreach (InventoryItem b in _invetory.GetBagels())
            {
                basket.AddBagelToBasket(b);
            }
    

            InventoryItem aMarmiteBagel = new InventoryItem()
            {
                Name="Marmite",
                SKU="MMT",
                Variant="Marmite",
                Price=120.00f
            };
            // that bagel that doesn't exist


            //following test should pass.. an attempt to remove a Bagel that isn't should be false
            Assert.IsFalse(basket.RemoveBagel(aMarmiteBagel));
        }

    }
}