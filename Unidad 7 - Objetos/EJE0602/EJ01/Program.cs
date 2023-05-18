
namespace EJ01
{
    internal class Program
    {
        private static void Main()
        {
            //decimal userFund = Utils.IntroduceMoney();
            VendingMachine vendingMachine = new(10, 2);
            vendingMachine.GenerateVendingMachineStock();
            int menuOption;

            do
            {
                Console.Write("---------------- VENDING MACHINE MANAGER--------------------\n\t1. Sell product.\n\t2. Refill vending machine.\n\t3. Show stock.\n\t4. Make purchase.\n\t0. Quit.\n\nSelect an option");
                menuOption = Utils.IntValue(0, 6);
                Console.Clear();
                switch (menuOption)
                {
                    case 1:
                        vendingMachine.ExtractProduct();
                        Utils.EndMethod();
                        break;
                    case 2:
                        vendingMachine.RefillAllProducts();
                        Utils.EndMethod();
                        break;
                    case 3:
                        vendingMachine.ShowStock();
                        Utils.EndMethod();
                        break;
                    //case 4:
                    //    vendingMachine.CompleteTransaction(userFund);
                    //    Utils.EndMethod();
                    //    break;
                    case 5:
                        vendingMachine.AddProduct();
                        Utils.EndMethod();
                        break;
                    case 6:
                        vendingMachine.RemoveProduct();
                        Utils.EndMethod();
                        break;
                }
            } while (menuOption != 0);
        }
    }
}
