﻿namespace EJ02
{
    internal class Program
    {
        private static void Main()
        {
            decimal userFund = Functions.IntroduceMoney();
            VendingMachine vendingMachine = new ();
            int menuOption;
            do
            {
                Console.Write("---------------- VENDING MACHINE MANAGER--------------------\n\t1. Sell product.\n\t2. Refill vending machine.\n\t3. Show stock.\n\t4. Make purchase.\n\t0. Quit.\n\nSelect an option");
                menuOption = Functions.IntValue(0, 4);
                Console.Clear();
                switch (menuOption)
                {
                    case 1:
                        vendingMachine.ExtractProduct();
                        Functions.EndMethod();
                        break;
                    case 2:
                        vendingMachine.RefillProduct();
                        Functions.EndMethod();
                        break;
                    case 3:
                        vendingMachine.ShowStock();
                        Functions.EndMethod();
                        break;
                    case 4:
                        vendingMachine.CompleteTransaction(userFund);
                        Functions.EndMethod();
                        break;
                }
            } while (menuOption != 0);
        }
    }
}
