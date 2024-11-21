using BasicMathsNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PokolenieNamespace;
using UtilityNamespace;

namespace lab1
{
    internal class Tests
    {
        private ZestawDanych[] Data;
        private double a,b,precision;
        int[] Ntab;
        double[] pktab;
        double[] pntab;
        int[] Ttab;
        bool elit;
        long countZestaw;
        
        public Tests(int[] Ntab, int[] Ttab, double[] pktab, double[] pntab, bool elit = true, double a = -4, double b = 12, double precision = 0.001) 
        {
            this.Ntab = Ntab;
            this.Ttab = Ttab;
            this.pktab = pktab;
            this.pntab = pntab;
            this.elit = elit;
            this.a = a;
            this.b = b;
            this.precision = precision;
           
            countZestaw = 0;
            //countZestaw = count(Nval) * ....
            foreach (int Nval in Ntab)
            {
                foreach (double pkval in pktab)
                {
                    foreach (double pnval in pntab)
                    {
                        foreach (int Tval in Ttab)
                        {
                            ++countZestaw;
                        }
                    }
                }
            }
            Data = new ZestawDanych[countZestaw];
        }

        

        public void setZestawyParallel()
        {

            int iterations = 100;
            //Pokolenie[] pokolenies;
            List<ZestawDanych> results = new List<ZestawDanych>();
            var options = new ParallelOptions { MaxDegreeOfParallelism = 32 };
            var combinations = from Nval in Ntab
                              from pkval in pktab
                              from pnval in pntab
                              from Tval in Ttab
                              select (Nval, pkval, pnval, Tval);
            Parallel.ForEach(combinations, options, combination =>
            {
                var (Nval, pkval, pnval, Tval) = combination;
                double dataAvg = 0;
                BasicMaths myFunc = new BasicMaths(a, b, precision);
                for (int i = 0; i < iterations; ++i)
                {
                    var pokolenies = Utility.CalcPokolenies(pkval, pnval, elit, Tval, Nval, myFunc);
                    dataAvg += pokolenies[pokolenies.Length - 1].getMaxFunc();
                }

                dataAvg /= iterations;

                lock (results)
                {
                    results.Add(new ZestawDanych(pkval, pnval, dataAvg, Nval, Tval));
                }
                Console.WriteLine($"Stop Tval={Tval}, Nval={Nval}, pkval={pkval}, pnval={pnval} dataAvg={dataAvg}");
            });

            // Skopiuj wyniki z listy do tablicy
            Data = results.ToArray();
        }


        public void SortData() 
        {
            Array.Sort(Data, (x, y) =>
            {
                int result = y.favg.CompareTo(x.favg);
                if (result == 0) // Jeśli Value1 są równe, porównaj Int1
                {
                    result = y.T.CompareTo(x.T);
                }
                if (result == 0) // Jeśli Int1 są równe, porównaj Int2
                {
                    result = y.N.CompareTo(x.N);
                }
                return result;
            });
        }

        
        public ZestawDanych[] getZestaw()
        {
            return Data;
        }
    }
}
