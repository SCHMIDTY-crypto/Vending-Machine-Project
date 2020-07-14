using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class MainMenu
    {

        //this page gives the user options to guide them thru the machine so we know which codes need to run (based on selection)
        public void StartingScreen()
        {
            Console.WriteLine("Please select a number from the Main Menu below.");
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine($"(1) Display Vending Machine Items");
            Console.WriteLine($"(2) Purchase");
            Console.WriteLine($"(3) Exit");
        }
    }
}
