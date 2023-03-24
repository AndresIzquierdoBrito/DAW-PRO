using EJ01;
using System.Diagnostics;

internal class Program
{
        //Queremos informatizar una lista de clientes, de los que queremos saber el nombre y sus apellidos, que no deben ser nulos.A cada cliente, 
        //le asignaremos un número que irá correlativo. Generaremos un menú que nos permita crear un cliente, buscar si un cliente pertenece a 
        //la lista, mostrar los clientes de la lista y eliminar un cliente de la lista.

    private static void Main(string[] args)
    {
        string name = "Pepe", surname = "Juanes", secondSurname = "Dolores";

        Client c = new Client(name, surname, secondSurname);
        Client c1 = new Client(name, surname, secondSurname);
        Console.WriteLine(c1.Name + c1.FirstSurname + c1.LastSurname + c1.Id + c.Id);
    }
}