using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsSolution
{
    // define the delegate for the event handler
    public delegate void myEventHandler(int value);

    class Account
    {
        private int theVal = 0;
        // declare the event handler
        public event myEventHandler thresholdReached;

        public int Val
        {
            set
            {
                this.theVal = value;
            }
        }

        public void deposit(int amount)
        {
            this.theVal += amount;

            if(this.theVal >= 550)
                this.thresholdReached(this.theVal);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // create the test class
            Account obj = new Account();

            // Use an anonymous delegate as the event handler
            obj.thresholdReached += delegate (int balance)
            {
                Console.WriteLine($"You reached your savings goal! You have {balance}");
            };

            string str;
            do
            {
                Console.WriteLine("How much to deposit: ");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    int amount = Int32.Parse(str);
                    obj.deposit(amount);
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }

    }

}
