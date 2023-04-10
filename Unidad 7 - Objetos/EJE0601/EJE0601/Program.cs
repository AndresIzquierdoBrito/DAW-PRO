using EJ01;
using System.Diagnostics;

internal class Program
{
        //Queremos informatizar una lista de clientes, de los que queremos saber el nombre y sus apellidos, que no deben ser nulos.A cada cliente, 
        //le asignaremos un número que irá correlativo. Generaremos un menú que nos permita crear un cliente, buscar si un cliente pertenece a 
        //la lista, mostrar los clientes de la lista y eliminar un cliente de la lista.

    private static void Main()
    {
        List<Client> clients = new List<Client>();
        int menuOption;
        do
        {
            Console.Write("---------------- CLIENT MANAGER SYSTEM --------------------\n\t1. Create client.\n\t2. Find client by ID\n\t3. Find if client exists\n\t4. Show all clients.\n\t5. Delete client.\n\t6. Exit\n\nSelect an option");
            menuOption = Methods.IntValue(1, 6);
            switch (menuOption)
            {
                case 1:
                    Console.Clear();
                    Methods.AddClient(clients);
                    break;

                case 2:
                    Console.Clear();
                    Methods.FindClient(clients);
                    break; 
                case 3:
                    Console.Clear();
                    Methods.FindIfClientExists(clients);
                    break;

                case 4: 
                    Console.Clear();
                    Methods.GetAllClients(clients);
                    break;

                case 5:
                    Console.Clear();
                    Methods.RemoveClient(clients);
                    break; 
            }
        } while (menuOption != 6);
        Console.Clear();
        Console.WriteLine("Program exited");
        Console.ReadKey();
    }
}