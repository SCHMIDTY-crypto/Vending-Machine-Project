using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Capstone.Food_Type;
using System.Runtime.CompilerServices;

namespace Capstone
{
    // created a class that reads over the text file provided and stores the item to a dictionary
    public class VendingMachineDictionary
    {
        //created a dictionary property
        public Dictionary<string, VendingMachineItem> VendingItemList = new Dictionary<string, VendingMachineItem>();
        
        //created a constructor that reads over the text file, and adds each line(producted) to the dictionary
        public VendingMachineDictionary()
        {
            string pathToVendingInventory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\..");
            string nameOfInventoryFile = "vendingmachine.csv";
            string fullPathToInventory = Path.Combine(pathToVendingInventory, nameOfInventoryFile);
            try
            {
                using (StreamReader sr = new StreamReader(fullPathToInventory))
                {
                    // loops over the file
                    while (!sr.EndOfStream)
                    {
                        //stores the current line to a variable
                        string currentLine = sr.ReadLine();
                        // splits on the ("|") and creates an array
                        string[] arrayVendingItem = currentLine.Split("|");
                        //if the 3 index of the array is = to Chip
                        if (arrayVendingItem[3] == "Chip")
                        {
                            //create an instance of the Chip class and named it chip... then stored that item to the dictionary
                            Chip chip = new Chip(arrayVendingItem[1], decimal.Parse(arrayVendingItem[2]), 5);
                            VendingItemList.Add(arrayVendingItem[0], chip);
                        }
                        else if (arrayVendingItem[3] == "Candy")
                        {
                            Candy candy = new Candy(arrayVendingItem[1], decimal.Parse(arrayVendingItem[2]), 5);
                            VendingItemList.Add(arrayVendingItem[0], candy);
                        }
                        else if (arrayVendingItem[3] == "Gum")
                        {
                            Gum gum = new Gum(arrayVendingItem[1], decimal.Parse(arrayVendingItem[2]), 5);
                            VendingItemList.Add(arrayVendingItem[0], gum);
                        }
                        else
                        {
                            Drink drink = new Drink(arrayVendingItem[1], decimal.Parse(arrayVendingItem[2]), 5);
                            VendingItemList.Add(arrayVendingItem[0], drink);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry, your file path was not found. Please try again.");
            }
        }
    }
}
