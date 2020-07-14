using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Chip : VendingMachineItem
    {
        public Chip(string itemName, decimal itemPrice, int itemStock) : base(itemName, itemPrice, itemStock)
        {
        }

        public override string MakeSound()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
