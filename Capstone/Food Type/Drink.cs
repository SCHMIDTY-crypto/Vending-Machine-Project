using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Food_Type
{
    class Drink : VendingMachineItem
    {
        public Drink(string itemName, decimal itemPrice, int itemStock) : base(itemName, itemPrice, itemStock)
        {
        }

        public override string MakeSound()
        {
            return "Glug Glug, Yum!";
        }
    }
}
