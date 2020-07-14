using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Food_Type
{
    public class Gum : VendingMachineItem
    {
        public Gum(string itemName, decimal itemPrice, int itemStock) : base(itemName, itemPrice, itemStock)
        {
        }

        public override string MakeSound()
        {
            return "Chew Chew, Yum!";
        }
    }
}
