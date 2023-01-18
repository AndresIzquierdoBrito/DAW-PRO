using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer06
{
    internal class Functions
    {
        public static decimal CalculateAvg(decimal[] array)
        {
            int amountValues = array.Length;
            decimal sum = 0;
            for (int i = 0; i < amountValues; i++)
                sum += array[i];

            return sum / amountValues;
        }
        public static void FillDecimalAray(ref decimal[] nums, int amountValues)
        {
            Random rnd = new Random();
            nums = new decimal[amountValues];
            for (int i = 0; i < amountValues; i++)
                nums[i] = rnd.Next(1, 100);
        }
    }
}
