using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMathsNamespace;
using PokolenieNamespace;

namespace UtilityNamespace
{
    internal class Utility
    {
        public static Random myFate = new Random();
        //utility.myFate.next(zakrs)
        public static void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }
        public static string Swapbit(string str,int index)
        {
            char[] chars = str.ToCharArray();
            if (chars[index] == '0') chars[index] = '1';
            else if (chars[index] == '1') chars[index] = '0';
            return new string(chars);
        }
        public static int[] CreateArray(int start, int end, int step)
        {
            List<int> list = new List<int>();
            for (int i = start; i <= end; i += step)
            {
                list.Add(i);
            }
            return list.ToArray();
        }

        public static double[] CreateArray(double start, double end, double step)
        {
            List<double> list = new List<double>();
            for (double i = start; i <= end; i += step)
            {
                list.Add(Math.Round(i, 2)); // Zaokrąglenie do 2 miejsc po przecinku
            }
            return list.ToArray();
        }

        public static double[] CreateAlternatingArray(double start, double max)
        {
            List<double> list = new List<double> { start };
            bool multiplyByFive = true;

            while (list[list.Count - 1] < max) // ^1 to ostatni element listy
            {
                double nextValue = multiplyByFive ? list[list.Count - 1] * 5 : list[list.Count - 1] * 2;
                if (nextValue > max) break;
                list.Add(nextValue);
                multiplyByFive = !multiplyByFive;
            }

            return list.ToArray();
        }
        public static Pokolenie[] CalcPokolenies(double pk, double pn, bool elita, int T, int N,BasicMaths myFunc)
        {
            Pokolenie[] pokolenies = new Pokolenie[T];
            double[] xreal = new double[N];
            for (int i = 0; i < N; ++i)
            {
                xreal[i] = myFunc.rand_xreal();
            }

            pokolenies[0] = new Pokolenie(xreal, myFunc, pk, pn, elita);
            pokolenies[0].caluculatePokolenie();

            for (int t = 1; t < T; ++t)
            {
                pokolenies[t] = new Pokolenie(pokolenies[t - 1].getXreal2(), myFunc, pk, pn, elita);
                pokolenies[t].caluculatePokolenie();
            }

           
            return pokolenies;
        }
    }
}
