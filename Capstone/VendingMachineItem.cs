using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    //abstract so we never create an instance of this in program
    public abstract class VendingMachineItem
    {
        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }

        public int ItemStock { get; set; }


        public VendingMachineItem (string itemName, decimal itemPrice, int itemStock)
        {
            this.ItemName = itemName;
            this.ItemPrice = itemPrice;
            this.ItemStock = itemStock;
        }

        public abstract string MakeSound();
    }
}
