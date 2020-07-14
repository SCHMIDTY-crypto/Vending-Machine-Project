using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Capstone
{
    public class CashRegister
    {
        public decimal MoneyInputed { get; set; }

        public string Change(decimal moneyInputed)
        {
            //set coin variables as both decimal for money & string for actual output

            decimal nickel = .05M;
            decimal dime = .10M;
            decimal quarter = .25M;
            string combinedQuarter = "";
            string combinedDime = "";
            string combinedNickel = "";

            //give them quarters if you can
            if (MoneyInputed >= quarter)
            {
                string quarterLabel = "number of quarters: ";
                int quarterCount = 0;

                //add to the amount of quarters when you give them a quarter. subtracts .25 from money in register
                while (MoneyInputed >= quarter)
                {
                    quarterCount++;
                    MoneyInputed -= quarter;
                }

                //has to be a string!
                quarterCount.ToString();
                combinedQuarter = $"{quarterLabel}{quarterCount}";
            }
            
            //Once money in register is lower than .25 -> same as quarters but with dimes
            if (MoneyInputed >= dime)
            {
                string dimeLabel = "number of dimes: ";
                int dimeCount = 0;

                while (MoneyInputed >= dime)
                {
                    dimeCount++;
                    MoneyInputed -= dime;
                }
                dimeCount.ToString();
                combinedDime = $"{dimeLabel}{dimeCount}";
            }

            //once money is lower than .10, give them the rest of their change in nickles, same process as quarters&dimes
            if (MoneyInputed >= nickel)
            {
                string nickelLabel = "number of nickels: ";
                int nickelCount = 0;

                while (MoneyInputed >= nickel)
                {
                    nickelCount++;
                    MoneyInputed -= nickel;
                }
                nickelCount.ToString();
                combinedNickel = $"and {nickelLabel}{nickelCount}";
                
            }

            //here we need to let them know how many of each coin they get back, based on their change
            return $"{combinedQuarter}  {combinedDime}  {combinedNickel}";
        }
        //constructor which allows us to use this in the program
        public CashRegister(decimal moneyInputed)
        {
            this.MoneyInputed = moneyInputed;
        }

        public CashRegister()
        {
        }
    }
}
