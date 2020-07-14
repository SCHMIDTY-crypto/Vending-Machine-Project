using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Logger

        
    {
   
        public void LogFeed(decimal totalMoney, decimal moneyAddedToRegister)
        {
            //here we're telling the program to log everything, but 4 files up from where we currently are working
            string logDirectory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\..");

            string auditLog = "Log.txt";

            string fullLogDirectory = Path.Combine(logDirectory, auditLog);
            
            //this is actually logging - typing in the date & time of transaction, how much money they put in and the balance of the machine
            try
            {
                using (StreamWriter sw = new StreamWriter(fullLogDirectory, true))
                {
                    sw.WriteLine($"{DateTime.Now} FEED MONEY: {moneyAddedToRegister.ToString("C2")} {totalMoney.ToString("C2")}");
                }
            }

            //if it doesn't work, this will keep the file from looping or breaking, or logging incomplete
            catch (Exception e)
            {
                Console.WriteLine("Error when logging transactions.");
            }

        }

        public void LogItem(string vendingMachine, decimal totalMoney, decimal itemPrice, string slot)
        {

            string logDirectory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\.."); ;

            string auditLog = "Log.txt";

            string fullLogDirectory = Path.Combine(logDirectory, auditLog);

            //same here, except now we're also including the transaction info such as the item cost and subtracting from the money they put in
            try
            {
                using (StreamWriter sw = new StreamWriter(fullLogDirectory, true))
                {
                    sw.WriteLine($"{DateTime.Now} {vendingMachine} {slot} {totalMoney.ToString("C2")} {(totalMoney - itemPrice).ToString("C2")}");
                }
            }

            //keeping it from breaking or incorrectly logging again
            catch (Exception e)
            {
                Console.WriteLine("Error when logging transactions.");
            }

        }

        public void LogChange(decimal totalMoney)
        {

            string logDirectory = Path.GetFullPath(Environment.CurrentDirectory + @"\..\..\..\.."); ;

            string auditLog = "Log.txt";

            string fullLogDirectory = Path.Combine(logDirectory, auditLog);

            //here we're logging the end of the transaction, and logging that we gave them their change & there's no money left in the machine
            try
            {
                using (StreamWriter sw = new StreamWriter(fullLogDirectory, true))
                {
                    sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {totalMoney.ToString("C2")} $0.00");
                }
            }

            //no breaky
            catch (Exception e)
            {
                Console.WriteLine("Error when logging transactions.");
            }

        }

    }
}
