using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXA05
{
    internal class Ficheros
    {
        static string CSVPath = "poblacion-cifras-absolutas.csv", ProcessedCSVPath = ("poblacion_datos_procesados.csv");
        static List<string> allCSVlines = new();
        static List<int> years = new();
        static List<double> popAverages = new();
        static List<string> municipios = new();

        public static bool FilesExists()
        {
            if (!File.Exists(CSVPath))
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
                allCSVlines = File.ReadAllLines(CSVPath).ToList();           // Guardo todos los contenidos del CSV en una lista: cada linea, un espacio en la lista
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static void GetYearsHeader(int lineLength, string[]line)
        {
            for (int i = 2; i < lineLength; i++)            // Saco los años del header dentro de PERIODO_AÑO
                if (!int.TryParse(line[i].Substring(8), out int yearValue))   // Revision del año
                    Console.WriteLine($"While validate the CSV data, the following error has been found: IN THE HEADER, YEARS MUST BE INT VALUES");
            else if (yearValue < 2000 || yearValue > 2023)
                    Console.WriteLine($"While validate the CSV data, the following error has been found: IN THE HEADER, YEARS MUST BE BETWEEN 2000 AND 2023");
                else
                    years.Add(yearValue);                   // Si el año esta validado, lo guardo en una lista
        }

        public static bool ValidateCSVData()
        {
            int amountCSVlines = allCSVlines.Count;
            string[] line;
            int lineLength;

            line = allCSVlines[0].Split(";");
            lineLength = line.Length;

            GetYearsHeader(lineLength, line);

            for (int i = 1; i < amountCSVlines; i++)        // Revision de datos despues del header
            {
                line = allCSVlines[i].Split(";");
                line[1] = line[1].Trim();                   // Desecho espacios delante y detras para poder revisar si esta realmente vacio
                if (line[1] == "")                               // Revision de los municipios
                {
                    Console.WriteLine($"While validate the CSV data, the following error has been found: Line {i + 1}: MUNICIPIO IS EMPTY.");
                    return false;
                }

                for (int j = 2; j < lineLength; j++)            // Revision de la poblacion
                {
                    if (!int.TryParse(line[j], out int popValue))
                    {
                        Console.WriteLine($"While validate the CSV data, the following error has been found: Line {i + 1}: POPULATION MUST BE INT.");
                        return false;
                    }
                    if (popValue < 0)
                    {
                        Console.WriteLine($"While validate the CSV data, the following error has been found: Line {i + 1}: POPULATION MUST BE POSITIVE (GREATER THAN 0).");
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool GenerateProcessedCSV()
        {
            if (!File.Exists(ProcessedCSVPath))
                if (!CreateFile(ProcessedCSVPath))
                {
                    Console.WriteLine("Cannot create the processed CSV file.");
                    return false;
                }
            else
                File.WriteAllText(ProcessedCSVPath, string.Empty); // Si el archivo ProcssedCSV ya existe, borra su contenido ya que estara escrito de previas ejecuciones

            return true;
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

        public static bool FillProcessedCSV()
        {
            try
            {
                StreamWriter sw = new(ProcessedCSVPath);
                sw.WriteLine("Municipio;AñoMin;ValorMin;AñoMax;ValorMax;Media");
                int amountYears = years.Count, amountCSVlines = allCSVlines.Count, maxValue, minValue;
                double avgPop;
                string[] line;
                int[] populationInts = new int[amountYears];
                for (int i = 1; i < amountCSVlines; i++)        // Escribo una a una todos los municipios y sus datos en el CSV
                {
                    line = allCSVlines[i].Split(";");
                    for (int j = 0; j < amountYears; j++)               // Meto en una nueva array simple, las poblaciones pero convertidas en enteros para tratar
                        populationInts[j] = Convert.ToInt32(line[j + 2]);
                    maxValue = populationInts.Max();
                    minValue = populationInts.Min();
                    avgPop = populationInts.Average(); 
                    sw.WriteLine($"{line[1]};{GetYearOfPop(populationInts, amountYears, minValue)};{minValue};{GetYearOfPop(populationInts, amountYears, maxValue)};{maxValue};{populationInts.Average():f2}");
                    popAverages.Add(avgPop);
                    municipios.Add(line[1]);
                }
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        static int GetYearOfPop(int[] pop, int amountYears, int value)
        {
            int yearIndex = 0;
            for (int i = 0; i < amountYears; i++)
                if (value == pop[i])
                    yearIndex = years[i];
            return yearIndex;
        }

        public static void GetUserInput()
        {
            double userIntroducedAvg = DoubleValue(popAverages.Min(), popAverages.Max());
            int amountAvgs = popAverages.Count;
            for (int i = 0; i < amountAvgs; i++)
            {
                if (userIntroducedAvg < popAverages[i])
                {
                    Console.WriteLine($"{municipios[i]}\t-->\t{popAverages[i]}");
                }
            }
        }
        public static double DoubleValue(double lowerLimit = double.MinValue, double upperLimit = double.MaxValue)
        /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
           si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            double userInput;
            bool check = false;
            Console.Write("Input a value");
            if (lowerLimit != double.MinValue && upperLimit != double.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            Console.WriteLine(":");
            do
            {
                if (!double.TryParse(Console.ReadLine(), out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine($"Input value not within the specified range. Enter a new value between {lowerLimit} and {upperLimit}:");
                else
                    check = true;
            } while (!check);
            return userInput;
        }
    }
}
