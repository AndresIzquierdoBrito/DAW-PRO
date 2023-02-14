using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProFunciones
{
    internal class CSTienda
    {
        public static void RealizarVenta(Persona[] data, List<int> ventaNumCopias, List<string> ventaNombre)
        {
            Console.WriteLine("==== List of names ====");
            foreach (Persona p in data)
            {
                Console.WriteLine(p.nombre);
            }
            Console.WriteLine("===================================\nSelect a name:");
            string nameSelected = SelectName(data);
            int indexSelected = FindIndexName(data, nameSelected);

            Console.Write("\nAmount of copies to make: ");
            int copiesToPrint = CSInscripcion.IntValue(lowerLimit: 0);
            if (copiesToPrint > AmountRemainingCopies(data, ventaNumCopias, ventaNombre, nameSelected, indexSelected))
            {
                Console.WriteLine("The amount selected is higher than the copies remaining.");
            }
            else
            {
                Console.WriteLine("Sale succesful, data stored.");
                ventaNombre.Add(nameSelected);
                ventaNumCopias.Add(copiesToPrint);
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void MostrarDatosVenta(Persona[] data, List<int> ventaNumCopias, List<string> ventaNombre)
        {
            Console.WriteLine("CURRENT FOTOCOPY QUOTAS\n-----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Name | Copies paid | Copies made | Remaining copies | Sales made");
            for (int i = 0; i < data.Length; i++)
                Console.WriteLine($"\n{data[i].nombre}\t\t{data[i].copiasPagadas}\t\t{AmountRemainingCopies(data, ventaNumCopias, ventaNombre, data[i].nombre, FindIndexName(data, data[i].nombre))}\t\t {amountSalesDone(data[i].nombre, ventaNombre)}");

            Console.WriteLine($"Total earnings: {ventaNumCopias.Sum() * 0.05:f2}");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static string SelectName(Persona[] data)
        {
            string selection;
            bool check = false;
            do
            {
                selection = Console.ReadLine();
                for (int i = 0; i < data.Length; i++)
                {
                    if (selection.ToLower() == data[i].nombre.ToLower())
                    {
                        check = true;
                    }
                }
                if (!check)
                    Console.WriteLine("You have not selected a name in the list. Try again.");
            } while (!check);
            return selection;
        }
        public static int AmountRemainingCopies(Persona[] data, List<int> ventaNumCopias, List<string> ventaNombre, string nameSelected, int indexOfName)
        {
            int totalAmount = 0, startingAmount = data[indexOfName].copiasPagadas;
            for (int i = 0; i < ventaNombre.Count; i++)
            {
                if (ventaNombre[i] == nameSelected)
                    totalAmount += ventaNumCopias[i];
            }
            return startingAmount - totalAmount;
        }
        public static int FindIndexName(Persona[] data, string nameSelected)
        {
            int index = 0;
            for (int i = 0; i > data.Length; i++)
                if (nameSelected == data[i].nombre)
                    index = i;
            return index;
        }
        public static int amountSalesDone(string user, List<string> ventaNombre)
        {
            int counter = 0;
            for (int i = 0; i < ventaNombre.Count; i++)
                if (user == ventaNombre[i])
                    counter++;
            return counter;
        }
    }
    
}
