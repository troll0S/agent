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
        BasicMaths myFunc;
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
            myFunc = new BasicMaths(a,b,precision);
            countZestaw = 0;
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

        public void setZestawy() 
        {
            double dataAvg;
            long j = 0;
            Pokolenie[] pokolenies;
            foreach (int Nval in Ntab)
            {
                foreach (double pkval in pktab)
                {
                    foreach (double pnval in pntab)
                    {
                        foreach (int Tval in Ttab)
                        {
                            dataAvg = 0;
                            for (int i = 0; i < 100; ++i)
                            {
                                pokolenies = Utility.CalcPokolenies(pkval, pnval, elit, Tval, Nval, myFunc);
                                dataAvg += pokolenies[Tval - 1].getMaxFunc();

                            }
                            dataAvg /= 100;
                            Data[j] = new ZestawDanych(pkval, pnval, dataAvg, Nval, Tval);
                            ++j;
                        }
                    }
                }
            }
        }

        public void setZestawyParallel()
        {

            long j = 0;
            //Pokolenie[] pokolenies;
            List<ZestawDanych> results = new List<ZestawDanych>();

            Parallel.ForEach(Ntab, Nval =>
            {
                Parallel.ForEach(pktab, pkval =>
                {
                    Parallel.ForEach(pntab, pnval =>
                    {
                        Parallel.ForEach(Ttab, Tval =>
                        {
                            Console.WriteLine($"Start Tval={Tval}, Nval={Nval}, pkval={pkval}, pnval={pnval}");
                            double dataAvg = 0;
                            for (int i = 0; i < 100; ++i)
                            {
                                var pokolenies = Utility.CalcPokolenies(pkval, pnval, elit, Tval, Nval, myFunc);
                                dataAvg += pokolenies[Tval - 1].getMaxFunc();
                            }
                            dataAvg /= 100;

                            lock (results)
                            {
                                results.Add(new ZestawDanych(pkval, pnval, dataAvg, Nval, Tval));
                            }
                            Console.WriteLine($"Finish Tval={Tval}, Nval={Nval}, pkval={pkval}, pnval={pnval}, Avg={dataAvg}");
                        });
                    });
                });
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
