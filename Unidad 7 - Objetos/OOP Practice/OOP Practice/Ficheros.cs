using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal class Ficheros
    {
        static string TurismoCSV = "Turismo.CSV";
        static readonly string[] MESES = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubbre", "Noviembre", "Diciembre" };
        static List<string> countries = new();
        static List<string> allCSVlines = new();

        public static bool FileExists()
        {
            if (!File.Exists(TurismoCSV))
            {
                Console.WriteLine("Cannot find base CSV file.");
                return false;
            }
            return true;
        }

        public static bool LoadFile()
        {
            try
            {
                allCSVlines = File.ReadAllLines(TurismoCSV).ToList();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static void CountryMenu()
        {
            string[] line = new string[1];
            Console.WriteLine("Elige el país o agrupación a seleccionar:");
            bool foundTotal = false;
            int option = 0;
            //allCSVlines.Find(line => line == "TOTAL");
            for (int i = 1; i < allCSVlines.Count - 1 && foundTotal == false; i++)
            {
                line = allCSVlines[i].Split(';');
                if (line[2] != "TOTAL")
                    countries.Add(line[2]);
                else
                    foundTotal = true;
            }
            ListCountries();
            Console.WriteLine("Elige una opción: ");
        }

        static void ListCountries()
        {
            int i = 1;
            foreach (string c in countries)
            {
                Console.WriteLine($"{i++}. {c}");
            }
        }

        static bool CreateFile(string filename)
        {
            try
            {
                File.CreateText(filename).Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}


