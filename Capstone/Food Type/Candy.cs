using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Food_Type
{
    public class Candy : VendingMachineItem
    {
        public Candy(string itemName, decimal itemPrice, int itemStock) : base(itemName, itemPrice, itemStock)
        {
        }

        public override string MakeSound()
        {
            return "Munch Munch, Yum!";
        }
    }
}
