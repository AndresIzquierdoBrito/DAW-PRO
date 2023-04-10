using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    internal class Methods
    {
        public static List<Client> AddClient(List<Client> listClients)
        {
            string name = ValidName();
            string firstSurname = ValidFirstSurname();
            string lastSurname = ValidLastSurname();

            Client client = new Client(name, firstSurname, lastSurname);

            listClients.Add(client);
            Console.WriteLine("Client added succesfully");
            EndMethod();
            return listClients;
        }

        public static List<Client> RemoveClient(List<Client> listClients)
        {
            if (listClients.Count == 0)
                Console.WriteLine("There are currently no clients");
            else
            {
                Console.Write("Select a client ID to remove:");
                int seekedId = IntValue(lowerLimit: 1), amountClients = listClients.Count;

                for (int i = 0; i < amountClients; i++)
                    if (seekedId == listClients[i].Id)
                    {
                        listClients.RemoveAt(i);
                        Console.WriteLine("Client removed succesfully");
                        EndMethod();
                        return listClients;
                    }

                Console.WriteLine($"Client with ID: {seekedId} not found."); 
            }
            EndMethod();
            return listClients;
        }

        public static void FindClient(List<Client> listClients)
        {
            if (listClients.Count == 0)
                Console.WriteLine("There are currently no clients");
            else
            {
                Console.Write("Select a client ID: available ids");
                int seekedId = IntValue(1, listClients.Count);
                Console.WriteLine($"{listClients[seekedId - 1].Name} {listClients[seekedId - 1].FirstSurname} {listClients[seekedId - 1].LastSurname}");
            }
            EndMethod();
        }

        public static void FindIfClientExists(List<Client> listClients)
        {
            if (listClients.Count == 0)
                Console.WriteLine("There are currently no clients");
            else
            {
                Console.WriteLine("Introduce name and surname(s) of the desired client: ");
                string nameToBeFound = ValidName();
                string[] clientToBeFound = nameToBeFound.Split(' ');
                int amountClients = listClients.Count;
                List<int> foundIDsIndex = new();
                try
                {
                    for (int i = 0; i < amountClients; i++)
                        if (listClients[i].Name == clientToBeFound[0] && listClients[i].FirstSurname == clientToBeFound[1] && (clientToBeFound.Length < 3 || listClients[i].LastSurname == clientToBeFound[2]))
                            foundIDsIndex.Add(listClients[i].Id);

                    if (foundIDsIndex.Count == 1)
                        Console.WriteLine($"Client {nameToBeFound} found. Assigned ID: {foundIDsIndex[0]}");
                    else if (foundIDsIndex.Count == 0)
                        Console.WriteLine("Client was not found");
                    else
                    {
                        Console.Write("\nMore than one client with the same name and surname(s) was found, found in with the following IDs: ");
                        foreach (int id in foundIDsIndex)
                            Console.Write($"{id} | ");
                    }
                    Console.WriteLine("");
                }
                catch
                {
                    Console.WriteLine("A name and a surname was expected.");
                }
            }
            EndMethod();
        }

        public static void GetAllClients(List<Client> listClients)
        {
            Console.WriteLine("Id\t\t\tName\t\tSurname(s)\n-----------------------------------------------------------");
            foreach (Client client in listClients)
                Console.WriteLine($"{client.Id}\t\t\t{client.Name}\t\t{client.FirstSurname} {client.LastSurname}");
            EndMethod();
        }

        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
           si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            int userInput;
            bool check = false;
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            Console.WriteLine(":");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine("Input value not within the specified range. Enter a new value between " + lowerLimit + " and " + upperLimit + ":");
                else
                    check = true;
            } while (!check);
            return userInput;
        }

        public static string ValidName()
        {
            string n;
            do
            {
                Console.Write("Name: ");
                n = Console.ReadLine()?.Trim() ?? "";
                Console.Clear();
                Console.WriteLine(n == "" ? "Invalid name, input again" : "");
            } while (n == "");
            return n;
        }

        public static string ValidFirstSurname()
        {
            string n;
            do
            {
                Console.Write("First surname: ");
                n = Console.ReadLine()?.Trim() ?? "";
                Console.Clear();
                Console.WriteLine(n == "" ? "Invalid surname, input again" : "");
            } while (n == "");
            return n;
        }

        public static string ValidLastSurname()
        {
            string n;
            Console.Write("Last surname (OPTIONAL): ");
            return n = Console.ReadLine()?.Trim() ?? "";
        }

        public static void EndMethod()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
