﻿namespace Ejer03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int values = Funciones.IntValue();
            int[] numeros = new int[values];

            Funciones.RellenarArrayRand(ref numeros, values);
            Console.WriteLine($"El array queda asi: {string.Join(", ", numeros)}");
        }
    }
}