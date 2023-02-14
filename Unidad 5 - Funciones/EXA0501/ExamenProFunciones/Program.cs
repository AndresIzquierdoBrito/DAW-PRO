using System.ComponentModel.DataAnnotations;

namespace ExamenProFunciones
{

    internal class Program
    {
        
        private static void Main(string[] args)
        {
            Console.WriteLine("==== Fotocopy machine system. User quotas ====");
            Persona[] users = CSInscripcion.GetStudentsData();

            int menuOption;
            Console.Clear();

            List<string> ventaNombre = new List<string>();
            List<int> ventaNumCopias = new List<int>();
            do
            {
                Console.WriteLine("[1] Make sale.\n[2] Show sale data.\n[3] Exit.");
                menuOption = CSInscripcion.IntValue();
                switch (menuOption)
                {
                    case 1: CSTienda.RealizarVenta(users, ventaNumCopias, ventaNombre); break;
                    case 2: CSTienda.MostrarDatosVenta(users, ventaNumCopias, ventaNombre); break;
                    case 3: break;
                    default: Console.WriteLine("Option not valid"); break;
                }
            } while (menuOption != 3);
        }
        
    }
}