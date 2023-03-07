using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT0502
{
    internal class Ficheros
    {
        static string EdadesCSV = "edades-medias-de-la-poblacion.csv", log = "errores.log";
        static List<double> avgAges = new();
        static List<string> lines = new();


        public static bool FilesExists()
        {
            if (!File.Exists(EdadesCSV))
            {
                logError("Cannot find base CSV file.");
                return false;
            }

            if (!File.Exists(log))
                if (!CreateFile(log))
                {
                    logError("Cannot create error log".);
                    return false;
                }

            return true;
        }
        public static bool VerifyCSVAges()
        {
            List<string> singleLine;
            for (int i = 1; i < lines.Count; i++)
            {
                singleLine = lines[i].Split(';').ToList();
                if (!int.TryParse(singleLine[0], out int intValue))
                {
                    logError($"Line {i}: CODMUN int expected.");
                    return false;
                }
                if (intValue <= 9999)
                {
                    logError($"Line {i}: CODMUN out of bounds at least 5 digits expected.");
                    return false;
                }
                if (intValue >= 100000)
                {
                    logError($"Line {i}: CODMUN out of bounds not more than 5 digits expected.");
                    return false;
                }
                if (singleLine[1] == "")
                {
                    logError($"Line {i}: MUNICIPIO is empty.");
                    return false;
                }
                else
                    singleLine[1] = singleLine[1].Trim();

                for (int j = 2; j < singleLine.Count; j++)
                {
                    if (!double.TryParse(singleLine[j], out double doubleValue))
                    {
                        logError($"Line {i}: AVERAGE {2019 - j} IS NOT DOUBLE.");
                        return false;
                    }
                    if (doubleValue <= 0)
                    {
                        logError($"Line {i}: AVERAGE {2019 - j} IS NOT POSITIVE.");
                        return false;
                    }
                    avgAges[i] += doubleValue;
                }
            }
            return true;
        }

        public static bool LoadFile()
        {
            try
            {
                lines = File.ReadAllLines(EdadesCSV).ToList();
                return true;
            }
            catch (Exception ex)
            {
                logError(ex.Message);
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
                logError(ex.Message);
                return false;
            }
        }

        public static void logError(string error)
        {
            Console.WriteLine(error);

            StreamWriter sw = new StreamWriter(log);
            sw.WriteLine(error);
            sw.Close();
        }
    }
}
