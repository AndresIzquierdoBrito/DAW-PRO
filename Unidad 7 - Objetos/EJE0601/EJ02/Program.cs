internal class Program
{
    private static void Main(string[] args)
    {
        int menuOption;
        do
        {
            Console.Write("---------------- VENDING MACHINE MANAGER--------------------\n\t1. Add game.\n\t2. Remove game.\n\t3. Show game libray.\n\t4. Quit.\n\nSelect an option ");
            menuOption = Functions.IntValue(1, 4);
            Console.Clear();
            switch (menuOption)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        } while (menuOption != 4);
    }
}