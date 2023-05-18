
namespace EXA0601
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("----- CREAR TIENDA ------\nNombre encargado:");
            string managerName = Utils.ValidManagerName();
            Console.WriteLine("Numero de telefono: ");
            //int telephoneNumber = Utils.ValidPhoneNumber();
            Shop shop = new Shop(managerName, 922274910);
            shop.CreateGameCatalog();
            Console.Clear();
            int opt = 0;

            do
            {
                Utils.ShowMenu();
                Console.Write("\nElija ");
                opt = Utils.IntValue(lowerLimit: 0, upperLimit: 4);
                Console.Clear();
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Tienda cerrada");
                        break;
                    case 1:
                        shop.RentGame();
                        Console.WriteLine("\n\n");
                        break;
                    case 2:
                        shop.ReturnGame();
                        Console.WriteLine("\n\n");
                        break;
                    case 3:
                        shop.ShowShopInfo();
                        Console.WriteLine("\n\n");
                        break;
                    case 4:
                        shop.ShowRentHistory();
                        Console.WriteLine("\n\n");
                        break;
                }
            } while (opt != 0);
        }
    }
} 