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

            if (table.Length == 0)
            {
                throw new ArgumentException("Tablica jest pusta."); // Obsługa pustej tablicy
            }

            foreach (double row in table)
            {
                if (r > begin && r <= end) // Sprawdzanie zakresu
                {
                    return i;
                }

                begin = end;
                ++i;

                if (i < table.Length) // Sprawdzanie przed aktualizacją end
                {
                    end = table[i];
                }
                else
                {
                    break; // Przerwanie pętli, gdy osiągnięto koniec tablicy
                }
            }

            return table.Length - 1; // Domyślnie zwraca ostatni indeks
        }
        public static bool isDrawn(double p)
        {
            
            return  p >= Utility.myFate.NextDouble();
            //Console.WriteLine($"{p} {a}");
            
        }
    }
}
