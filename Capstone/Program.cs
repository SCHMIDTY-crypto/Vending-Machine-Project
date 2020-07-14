using Capstone.Food_Type;
using System;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {

            //here is where the program actually runs and will log the transaction choices
            string logDirectory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\..");
            string auditLog = "Log.txt";
            string fullLogDirectory = Path.Combine(logDirectory, auditLog);
            Logger audit = new Logger();
            Console.WriteLine("Welcome to the Interdimensional Vending Machine!");
            Console.WriteLine();
            //this next line is creating an instance of CashRegister so that we can set the stored money in the machine at the beginning to zero & manipulate it
            CashRegister storedMoney = new CashRegister(0M);
            VendingMachineDictionary vendingMachine = new VendingMachineDictionary();
            MainMenu firstDisplay = new MainMenu();
            string userMainMenuResponse = "";
            //if the user did not choose to exit, then we're doing something!
            while (userMainMenuResponse != "3")
            {
                firstDisplay.StartingScreen();
                userMainMenuResponse = Console.ReadLine();
                Console.WriteLine();

                //they picked list so this shows them the available items, as well as their prices, stock amount and location
                if (userMainMenuResponse == "1")
                {
                    Console.Clear();
                    foreach (string key in vendingMachine.VendingItemList.Keys)
                    {
                        //if we don't have any we can't sell it, let them know it's sold out
                        if (vendingMachine.VendingItemList[key].ItemStock == 0)
                        {
                            Console.WriteLine($"{key} {vendingMachine.VendingItemList[key].ItemName} " +
                            $"{vendingMachine.VendingItemList[key].ItemPrice} " +
                            $"SOLD OUT!");
                        }
                        //if we have it let's sell it, let them know the name, price, and how much of it is left
                        else
                        {
                            Console.WriteLine($"{key} {vendingMachine.VendingItemList[key].ItemName} " +
                            $"{vendingMachine.VendingItemList[key].ItemPrice} " +
                            $"{vendingMachine.VendingItemList[key].ItemStock}");
                        }
                    }
                }
                //this means they are choosing to purchase something
                else if (userMainMenuResponse == "2")
                {
                    Console.Clear();
                    //the line above this has cleared away the previous menu and selections; makes it cleaner

                    //the line below this is storing whether the user is adding money, choosing an item or done
                    string userPurchaseResponse = "";
                    while (userPurchaseResponse != "3")
                    {
                        PurchaseMenu purchaseMenu = new PurchaseMenu();
                        purchaseMenu.PurchaseMenuScreen();
                        Console.WriteLine();
                        Console.WriteLine($"Current Money Provided: ${storedMoney.MoneyInputed}");
                        userPurchaseResponse = Console.ReadLine();
                        //user wants to input money
                        if (userPurchaseResponse == "1")
                        {
                            Console.Clear();
                            Console.WriteLine($"Please enter the value of the bill you've paid with (Valid values: 1, 2, 5, or 10).");
                            string usersInsertedMoney = Console.ReadLine();
                            decimal moneyAddedToRegister = 0;
                            //comparing the user's input amount to a valid option
                            if (usersInsertedMoney == "1")
                            {
                                moneyAddedToRegister = 1;
                            }
                            else if (usersInsertedMoney == "2")
                            {
                                moneyAddedToRegister = 2;
                            }
                            else if (usersInsertedMoney == "5")
                            {
                                moneyAddedToRegister = 5;
                            }
                            else if (usersInsertedMoney == "10")
                            {
                                moneyAddedToRegister = 10;
                            }
                            //if the amount the user inputed is not valid it will kick out this error message
                            else
                            {
                                Console.WriteLine("Sorry but the amount you used isn't valid for our machine, or you used a \"$\"!");
                                Console.WriteLine();
                            }
                            // this is the key reason for the moneyAddedToRegister variable, it allows us to log the money added to the text file along with whats already stored in the register
                            if (moneyAddedToRegister > 0)
                            {
                                storedMoney.MoneyInputed += moneyAddedToRegister;
                                audit.LogFeed(storedMoney.MoneyInputed, moneyAddedToRegister);
                            }
                        }
                        //user wants to select an item to buy
                        else if (userPurchaseResponse == "2")
                        {
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Please select an item below using the slot number (A1, A2, A3, etc.)");
                                Console.WriteLine();
                                string userItemSlotLocation;
                                foreach (string key in vendingMachine.VendingItemList.Keys)
                                {
                                    //will not let user purchase something that is out of stock, spits out error message
                                    if (vendingMachine.VendingItemList[key].ItemStock == 0)
                                    {
                                        Console.WriteLine($"{key} {vendingMachine.VendingItemList[key].ItemName} " +
                                        $"{vendingMachine.VendingItemList[key].ItemPrice} " +
                                        $"SOLD OUT!");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{key} {vendingMachine.VendingItemList[key].ItemName} " +
                                        $"{vendingMachine.VendingItemList[key].ItemPrice} " +
                                        $"{vendingMachine.VendingItemList[key].ItemStock}");
                                    }
                                }
                                //records what the user selected
                                userItemSlotLocation = Console.ReadLine();
                                Console.Clear();
                                audit.LogItem(vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemName, storedMoney.MoneyInputed,
                                    vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemPrice, userItemSlotLocation.ToUpper());
                                // checking if the user selection is in the dictionary
                                if (!vendingMachine.VendingItemList.ContainsKey(userItemSlotLocation.ToUpper()))
                                {
                                    Console.WriteLine("Sorry, that is an invalid slot location. Try again!");
                                }
                                else if (vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemStock == 0)
                                {
                                    Console.WriteLine("Sorry, that item is sold out. Please try again.");
                                }
                                else if (vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemPrice > storedMoney.MoneyInputed)
                                {
                                    Console.WriteLine("CHEAPSKATE.......I NEED MORE MONEY THAN THAT!");
                                }
                                else if (vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemStock > 0)
                                {
                                    // takes the money in the register and subtracts the item price from it
                                    storedMoney.MoneyInputed -= vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemPrice;
                                    // lowers the stock of the item by 1
                                    vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemStock--;
                                    Console.WriteLine($"{vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemName} " +
                                        $"{vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].ItemPrice} {storedMoney.MoneyInputed}");
                                    Console.WriteLine(vendingMachine.VendingItemList[userItemSlotLocation.ToUpper()].MakeSound());
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Sorry, that is an invalid entry!");
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }
                        else if (userPurchaseResponse == "3")
                        {
                            //ends the loop
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Menu option! Try again.");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                    audit.LogChange(storedMoney.MoneyInputed);
                    //giving change
                    Console.WriteLine(storedMoney.Change(storedMoney.MoneyInputed));
                    //resets money in register to 0
                    storedMoney.MoneyInputed = 0M;
                    Console.WriteLine();
                }
                else if (userMainMenuResponse == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Menu option! Try again.");
                    Console.WriteLine();
                }
            }
        }
    }
}
