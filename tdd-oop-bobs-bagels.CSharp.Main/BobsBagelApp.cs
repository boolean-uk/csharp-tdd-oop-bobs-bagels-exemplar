using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tdd_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BobsBagelApp
    {
        bool running = true;

        private Inventory _inventory;
        private Basket _basket;

        public BobsBagelApp()
        {           
            Initialize();
            
            Welcome();
            ShowMenu();
            WriteOptions();

            string choice = string.Empty;

            while (running)
            {
                Console.WriteLine("Choose a menu item..");
                Console.WriteLine();
                choice = Console.ReadLine();
                Console.WriteLine($"{choice} selected..");
                
                if(_inventory.DoesSkuExist(choice))
                {
                    if(_basket.AddBagelToBasket(_inventory.GetSkuType(choice).FirstOrDefault()))
                    {
                        Console.WriteLine("Added");
                        ShowBasket();
                    }
                        

                    
                    
                }
                else
                {

                
               
                switch (choice)
                {                    
                    
                    case "q":
                    case "Q":
                        Stop();
                        break;

                    case "1":
                        ShowMenu();
                        WriteOptions();
                        break;
                    
                    case "2":
                        ShowBasket();
                        WriteOptions();
                        break;

                    case "3":
                        ShowBasketDelete();
                        break;
                        
                    case "4":
                        break;

                   
                    default:
                        WriteOptions();
                        
                        Console.WriteLine($"{choice} is not an item");
                        WriteOptions();
                        break;
                }
                }

            }
        }
        private void WriteOptions()
        {
            WriteSpacer();
            Console.WriteLine($"Enter an option:");
            Console.WriteLine($"1 Show Menu");
            Console.WriteLine($"2 Show Basket");
            Console.WriteLine($"3 Remove an item from Basket");
            Console.WriteLine($"4 Clear basket");
            Console.WriteLine($"5 Checkout");
            Console.WriteLine($"q Quit");
            Console.Beep();
        }
        private void ShowBasket()
        {
            WriteSpacer();
            _basket.Items.ForEach(i => {
                Console.WriteLine(i.ItemDetails);
            });

            Console.WriteLine($"Total:  {_basket.Items.Sum(x => x.Price)}");
                
        }
        private void ShowBasketDelete()
        {
            WriteSpacer();
            int itemNumber = 1;
            _basket.Items.ForEach(i => {
                Console.WriteLine($"Select {itemNumber} to delete {i.Name}");
            });
        }
        private void RemoveItemFromBasket()
        {
            ShowBasketDelete();
            Console.WriteLine("Which item should be removed? e.g. 1");
            string itemForRemoval = Console.ReadLine();

        }
        private void Stop()
        {
            running = false;
            
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome To Bobs Bagels App");
        }

        private void Initialize()
        {
            _inventory = new Inventory();
            _basket = new Basket();
        }

        private void ShowMenu()
        {

            WriteMenuSKUType("Bagel");
            WriteMenuSKUType("Filling");
            WriteMenuSKUType("Coffee");                

        }
        private void WriteMenuSKUType(string skuType)
        {
            Console.WriteLine();
            Console.WriteLine($"{skuType}'s");
            WriteSpacer();            
            _inventory.GetInventoryItemByName(skuType).ForEach(x => {
                //Console.WriteLine($"{x.Variant} {x.Price.ToString("C")}");
                Console.WriteLine($"{x.ItemDetails}");
            });
            Console.WriteLine();

        }
        private void WriteSpacer()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();
        }
       
    }
}
