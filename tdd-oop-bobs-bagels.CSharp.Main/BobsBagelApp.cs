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
           

            string choice = string.Empty;

            while (running)
            {
                ShowMenu();
                ShowBasket();
                ShowOptions();
                Console.WriteLine("Choose a menu item..");
                Console.WriteLine();
                choice = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"{choice} selected..");
                
                if(_inventory.DoesSkuExist(choice))
                {
                    if(_basket.Items.Count<=5)
                    {
                        _basket.AddBagelToBasket(_inventory.GetSkuType(choice).FirstOrDefault());
                    }
                    else
                    {
                       
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
                            Console.Clear();
                            ShowMenu();
                            ShowOptions();
                            break;
                    
                   
                    case "3":
                            Console.Clear();
                            RemoveItemFromBasket();
                        break;
                        
                    case "4":
                            Console.Clear();
                            _basket.Items.Clear();
                            Console.WriteLine("Cleared basket...");
                            ShowMenu();
                            break;

                   
                    default:
                        ShowOptions();
                        
                        Console.WriteLine($"{choice} is not an item");
                        ShowOptions();
                        break;
                }
                }

            }
        }
        private void ShowOptions()
        {
            WriteSpacer();
            Console.WriteLine($"Enter an option:");
            Console.WriteLine($"1 Show Menu");
            Console.WriteLine($"2 Show Basket");
            Console.WriteLine($"3 Remove an item from Basket");
            Console.WriteLine($"4 Clear basket");
            Console.WriteLine($"5 Checkout");
            Console.WriteLine($"q Quit");
            Console.WriteLine("Or simply enter an item code to add to basket.. e.g.  entering COFB will add coffee");
            if (_basket.Items.Count >= _basket.MaxCapacity)
            {
                Console.WriteLine("ps.. basket has reached full capacity!");
            }
            //Console.Beep();
        }
        private void ShowBasket()
        {
            
            WriteSpacer();
            if(_basket.Items.Count > 0)
            {
                Console.WriteLine("Your Bobs Bagels Basket:");
                _basket.Items.ForEach(i => {
                    Console.WriteLine("{0,20}|{1,20}|{2,20}", i.SKU, i.Variant, i.Price);                                
                });
                Console.WriteLine();
                Console.WriteLine($"                  Total:  {_basket.Items.Sum(x => Math.Round(x.Price,2))}");
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
            else
            {
                WriteSpacer();
                Console.WriteLine("Basket is empty..");
            }                          
        }
        private void ShowBasketDelete()
        {
            Console.Clear();
            Console.WriteLine("Delete an Item from Basket.....");
            int itemNumber = 1;
            _basket.Items.ForEach(i => {
                Console.WriteLine($"{itemNumber} to delete {i.Name}");
                itemNumber++;
            });
            Console.WriteLine("0 for main menu");            

        }
        private void RemoveItemFromBasket()
        {
            if(_basket.Items.Count>0)
            {
                string input = string.Empty;
                while(input!="0"&&_basket.Items.Count>0)
                {
                    ShowBasketDelete();
                    Console.WriteLine("Which item should be removed? e.g. 1");
                    input = Console.ReadLine();
                    if(input!="0")
                    {
                        try
                        {
                            _basket.Items.RemoveAt(int.Parse(input)-1);


                        }
                        catch(Exception ex)
                        {

                        }

                    }
                }
            }            
            
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
                Console.WriteLine("{0,20}|{1,20}|{2,20}",x.SKU,x.Variant,x.Price);
            });
            Console.WriteLine();

        }
        private void WriteSpacer()
        {
            Console.WriteLine("-----------------------------------------------------------------------");            
        }
       
    }
}
