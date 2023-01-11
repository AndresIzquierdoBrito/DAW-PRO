﻿using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string[,] product;
        int reducedProducts = 3, amountOfProducts;
        bool check = false;

        Console.Write("Bienvenido a Mercados Sonia!\n");

        do
        {
            Console.Write("Introduce la cantidad de productos que va a comprar: ");
            // Validacion de entrada de amountOfProducts, numerico y entero.
            if (int.TryParse(Console.ReadLine(), out amountOfProducts))
            {
                if (amountOfProducts <= 0)
                    Console.WriteLine("La cantidad de products no puede ser negativa.");
                else check = true;
            }
            else Console.WriteLine("El valor introducido tiene que ser numerico.");

        } while (!check);
        check = false;

        product = new string[2, amountOfProducts];

        Console.WriteLine(amountOfProducts);
        int cont = 0;
        decimal check0;
        //int i = 0, j = 0;

        //Columna 1, nombres de producto; columna 2, precio de producto
        for (int i = 0; i < amountOfProducts; i++)
        {
            Console.Write($"Introduce el nombre del producto [{i + 1}]: ");
            product[0, i] = Console.ReadLine();

            Console.Write($"Introduce el precio del producto [{i + 1}]: ");
            do
            {
                // Guardamos el precio del product en un string, pero despues lo convertimos en entero para revisar si lo es.
                product[1, i] = Console.ReadLine();
                if (decimal.TryParse(product[1, i], out check0))
                {
                    if (Convert.ToDecimal(product[1, i]) > 0)
                        check = true;
                }
            } while (!check);

            Console.WriteLine($"Nombre prod 1: {product[0, i]}       Precio prod 1: {product[1,i]}"); 
        }

        //do
        //{
        //    Console.WriteLine($"Introduce el nombre del producto {cont + 1}");
        //    product[i, j] = Console.ReadLine();

        //    
        //    Console.WriteLine(product[i, j]);
        //} while (cont > amountOfProducts);

    }
}