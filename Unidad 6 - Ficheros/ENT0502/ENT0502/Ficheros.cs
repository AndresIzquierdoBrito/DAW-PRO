using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT0502
{
    internal class Ficheros
    {
        static string EdadesCSV = "edades-medias-de-la-poblacion.csv", log = "errores.log", mediaCSV = "media_poblacion.csv";
        static List<double> avgAges = new(); // Lista donde se guardan las medias
        static List<string> municipioList = new();  // Lista donde se guardan los nombres de municipios
        static List<string> lines = new();  // Lista donde se guardan todas las lineas del CSV


        public static bool FilesExists()
        {
            if (!File.Exists(EdadesCSV))
            {
                Console.WriteLine("Cannot find base CSV file.");
                return false;
            }

            if (!File.Exists(log))
            {
                if (!CreateFile(log))
                {
                    Console.WriteLine("Cannot create error log");
                    return false;
                }
            }
            else
            {
                File.WriteAllText(log, string.Empty); // Si el archivo log ya existe, borra su contenido
            }
            return true;
        }

        public static bool LoadFile()
        {
            try
            {
                lines = File.ReadAllLines(EdadesCSV).ToList();           // Guardo todos los contenidos del CSV en una lista: cada linea, un espacio en la lista
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static bool VerifyCSVAges()    // Verificacion y validacion de todos los datos dentro del CSV dado
        {
            List<string> singleLine;
            double sum = 0;
            int amountOfLineData;
            for (int i = 1; i < lines.Count; i++)
            {
                singleLine = lines[i].Split(';').ToList();
                amountOfLineData = singleLine.Count;                    // Guardo la cantidad de datos para hacer la media
                singleLine[1] = singleLine[1].Trim();                   // Desecho espacios delante y detras para poder revisar si esta realmente vacio
                if (!int.TryParse(singleLine[0], out int intValue))
                {
                    logError($"Line {i + 1}: CODMUN INT expected.");
                    return false;
                }
                if (intValue <= 9999)
                {
                    logError($"Line { i+ 1}: CODMUN out of bounds AT LEAST 5 digits expected.");
                    return false;
                }
                if (intValue >= 100000)
                {
                    logError($"Line {i + 1}: CODMUN out of bounds NO MORE than 5 digits expected.");
                    return false;
                }
                if (singleLine[1] == "")
                {
                    logError($"Line {i + 1}: MUNICIPIO is empty.");
                    return false;
                }
                else
                {
                    municipioList.Add(singleLine[1]);                 //Guardo en orden la lista de municipios
                }

                for (int j = 2; j < amountOfLineData; j++)
                {
                    if (!double.TryParse(singleLine[j], out double doubleValue))
                    {
                        logError($"Line {i + 1}: AVERAGE YEAR {2019 - j} IS NOT DOUBLE.");
                        return false;
                    }
                    if (doubleValue <= 0)
                    {
                        logError($"Line {i + 1}: AVERAGE YEAR {2019 - j} IS NOT POSITIVE.");
                        return false;
                    }
                    sum += doubleValue;
                }
                avgAges.Add(sum/amountOfLineData);
                sum = 0;
            }
            return true;
        }

        public static bool GenerateCSVAvgPopulation()   // Crea el nuevo archivo CSV donde se guardaran las lineas de los datos tratados
        {
            if (!CreateFile(mediaCSV))
            {
                Console.WriteLine("Cannot create 'EdadesCSV' file");
                return false;
            }
            try
            {
                StreamWriter sw = new(mediaCSV);
                sw.WriteLine("MUNICIPIO;AVG_AGE");      //Introduzco header manualmente
                for (int i = 0; i < lines.Count - 1; i++)
                {
                    sw.WriteLine($"{municipioList[i]};{avgAges[i]:f2}");
                }
                sw.Close();
                Process.Start("notepad.exe", mediaCSV);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); 
                return false;
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

        static void logError(string error)      // Escribo en el error.log cualquier error pasado por parametro                     
        {
            Console.WriteLine(error);
            StreamWriter sw = new StreamWriter(log);
            sw.WriteLine(error);
            sw.Close();
            Process.Start("notepad.exe", log);
        }
    }
}
