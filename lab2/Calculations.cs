using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityNamespace;

namespace CalculationsNamesapce
{
    internal class Calculations
    {
        public static double calculatep(double gx, double[] table)
        {
            double sum = 0;
            foreach (double row in table)
            {
                sum += row;
            }
            return gx/sum;
        }
        public static int findindex(double r, double[] table)
        {
            int i = 0;
            double begin = 0;
            double end = table[0];
            foreach (double row in table)
            {
                if(r > begin &&  r < end)
                {
                    return i;
                }
                else
                {
                    begin = end;
                    ++i;
                    end = table[i];
                }

            }
            return table.Length-1;
        }
        public static bool isDrawn(double p)
        {
            
            return  p >= Utility.myFate.NextDouble();
            //Console.WriteLine($"{p} {a}");
            
        }
    }
}
