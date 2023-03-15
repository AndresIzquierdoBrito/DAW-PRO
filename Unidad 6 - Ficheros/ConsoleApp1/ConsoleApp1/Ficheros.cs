using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ficheros
    {
        static string TurismoCSV = "Turismo.CSV";
        static List<string> allCSVlines = new();
        static List<string> countries = new();
        static List<string> years = new();
        static List<int> yearLinePosition = new();
        static readonly string[] MONTHS = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubbre", "Noviembre", "Diciembre" };


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
                Console.WriteLine($"Error while trying to load file. \n {ex}");
                return false;
            }
        }

        public static int CountryMenu()
        {
            string[] line;
            bool foundTotal = false;
            int amountCSVlines = allCSVlines.Count;
            Console.WriteLine("Elige el país o agrupación a seleccionar:");
            for (int i = 1; i < amountCSVlines - 1 && foundTotal == false; i++)
            {
                line = allCSVlines[i].Split(';');
                if (line[2] != "TOTAL")
                    countries.Add(line[2]);
                else
                    foundTotal = true;
            }
            ListCountries(); // List all of the countries in the CSV file
            Console.WriteLine("Elige una opción: ");
            return Functions.IntValue(lowerLimit: 1, upperLimit: countries.Count) - 1; //Devuelve la opcion elegida
        }
        static void ListCountries()
        {
            int i = 1;
            foreach (string c in countries)
            {
                Console.WriteLine($"{i++}. {c}");
            }
        }

        public static int YearMenu()
        {
            Console.Clear();
            string[] line;
            int amountCSVlines = allCSVlines.Count, amountCountries = countries.Count;
            Console.WriteLine("Elige el año a seleccionar:");
            for (int i = 1; i < amountCSVlines - 1; i += (amountCountries + 1) * 13)
            {
                line = allCSVlines[i].Split(';');
                years.Add(line[0]);
                yearLinePosition.Add(i);
            }
            ListYears(); // List all of the years in the CSV file
            Console.WriteLine("Elige una opción: ");
            return Functions.IntValue(lowerLimit: 1, upperLimit: years.Count) - 1;
        }

        static void ListYears()
        {
            int i = 1;
            foreach (string y in years)
            {
                Console.WriteLine($"{i++}. {y}");
            }
        }

        public static void ListSelectedData(int countryOption, int yearOption)
        {
            string[] line;
            int amountCountries = countries.Count, pos = yearLinePosition[yearOption] + countryOption, monthCounter = 0;

            Console.WriteLine(pos + amountCountries * 13);
            Console.Clear();
            Console.WriteLine($"\tPAIS: {countries[countryOption]}\n------------------------------------------------\n\tAÑO: {years[yearOption]}");
            for (int j = pos; j < pos + (amountCountries + 1) * 12; j += amountCountries + 1)
            {
                line = allCSVlines[j].Split(";");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"Mes: {MONTHS[monthCounter]}\t\t4 estrellas: {line[6]}\t\t5 estrellas: {line[7]}\t\tSUMA: {Convert.ToInt32(line[6]) + Convert.ToInt32(line[7])} ");
                monthCounter++;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        }
    }
}
