using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BasicMathsNamespace;
using CalculationsNamesapce;
using UtilityNamespace;

namespace PokolenieNamespace
{
    internal class Pokolenie
    {
        BasicMaths myFunc;
        int nValue;
        double pk, pn;
        bool elita;
        double[] xreal;
        string[] xbin ;
        double[] funcx;
        double[] funcgx;
        double[] p;
        double[] q;
        double[] r;
        double[] xrealselection                             ;
        string[] xbinselection;
        bool[] parents;
        int[] pairs ;
        int[] pc;
        string[] child;
        string[] pokrzyzu;
        string[] mutacje;
        string[] xbinmutacja;
        double[] xrealmutacja;
        double[] funcx2;
        double[] maxVal = new double[2];
        double[] minVal = new double[2];
        double avgVal;


        public Pokolenie(double[] xreal,BasicMaths basicMaths,double pk,double pn,bool elita) 
        {
            myFunc = basicMaths;
            this.xreal = xreal;
            this.pk = pk;
            this.pn = pn;
            this.elita = elita;
            nValue = xreal.Length;
            xbin = new string[nValue];
            funcx = new double[nValue];
            funcgx = new double[nValue];
            p = new double[nValue];
            q = new double[nValue];
            r = new double[nValue];
            xrealselection = new double[nValue];
            xbinselection = new string[nValue];
            parents = new bool[nValue];
            pairs = new int[nValue];
            pc = new int[nValue];
            child = new string[nValue];
            pokrzyzu = new string[nValue];
            mutacje = new string[nValue];
            xbinmutacja = new string[nValue];
            xrealmutacja = new double[nValue];
            funcx2 = new double[nValue];
            maxVal = new double[2];
            minVal = new double[2];
            
        }

        public void caluculatePokolenie()
        {
            calcFuncx();
            calcXbin();
            setMax();
            setMin();
            calcFuncgx();
            calcP();
            calcR();
            calcQ();
            calcXrealselection();
            calcXbinselection();
            calcChilds();
            calcMutations();
            if (this.elita)
            {
                calcElite();
            }
            calcAvg();
        }

        private void calcFuncx()
        {
            for (int i = 0; i < nValue; ++i)
            {

                funcx[i] = myFunc.func(xreal[i]);
            }
        }

        private void calcXbin()
        {
            for (int i = 0; i < nValue; ++i)
            {
                xbin[i] = myFunc.calculate_xbin(myFunc.calculate_xint(xreal[i]));
            }
        }
        private void setMax()
        {
            maxVal[0] = myFunc.max_in_table(funcx);
            maxVal[1] = xreal[Array.IndexOf(funcx, maxVal[0])];
        }
        private void setMin()
        {
            minVal[0] = myFunc.min_in_table(funcx);
            minVal[1] = xreal[Array.IndexOf(funcx, minVal[0])];
        }

        private void calcFuncgx()
        {
            for (int i = 0; i < nValue; ++i)
            {
                funcgx[i] = myFunc.func_gx_max(xreal[i], minVal[0]);
            }
        }
        private void calcP()
        {
            for (int i = 0; i < nValue; ++i)
            {
                p[i] = Calculations.calculatep(funcgx[i], funcgx);
            }
        }
        private void calcR()
        {
            for (int i = 0; i < nValue; ++i)
            {
                r[i] = Utility.myFate.NextDouble();
            }
        }
        private void calcQ()
        {
            q[0] = p[0];
            for (int i = 1; i < nValue; ++i)
            {
                q[i] = q[i - 1] + p[i];
            }
        }
        private void calcXrealselection()
        {
            for (int i = 0; i < nValue; ++i)
            {

                xrealselection[i] = xreal[Calculations.findindex(r[i], q)];

            }
        }
        private void calcXbinselection()
        {
            for (int i = 0; i < nValue; ++i)
            {
                xbinselection[i] = myFunc.calculate_xbin(myFunc.calculate_xint(xrealselection[i]));

            }
        }
        private void calcChilds()
        {
            for (int i = 0; i < nValue; ++i)
            {
                parents[i] = Calculations.isDrawn(this.pk);

            }
            int tmp = 0;
            int pre = 0;
            for (int i = 0; i < nValue; ++i)
            {
                if (parents[i])
                {
                    if (tmp == 0)
                    {
                        pairs[i] = i;
                        tmp = 1;
                        pre = i;
                    }
                    else
                    {
                        pairs[i] = i;
                        tmp = 0;
                        Utility.Swap(ref pairs[i], ref pairs[pre]);
                        pc[i] = pc[pre] = Utility.myFate.Next(1, myFunc.getL());
                        pre = 0;

                    }
                }
            }
            for (int i = 0; i < nValue; ++i)
            {
                if (parents[i])
                {
                    child[i] = xbinselection[i];
                    child[pairs[i]] = xbinselection[pairs[i]];
                    myFunc.childs(pc[i], ref child[i], ref child[pairs[i]]);
                    i = pairs[i];
                }
            }

            for (int i = 0; i < nValue; ++i)
            {
                if (parents[i])
                {
                    pokrzyzu[i] = child[i];
                }
                else
                {
                    pokrzyzu[i] = xbinselection[i];
                }
            }
        }

        private void calcMutations()
        {
            for (int i = 0; i < nValue; ++i)
            {
                xbinmutacja[i] = pokrzyzu[i];
                for (int j = 0; j < pokrzyzu[i].Length; ++j)
                {

                    if (Calculations.isDrawn(this.pn))
                    {
                        mutacje[i] += (j + 1).ToString() + " ";
                        xbinmutacja[i] = Utility.Swapbit(xbinmutacja[i], j);
                    }
                }
                xrealmutacja[i] = myFunc.calculate_xreal(myFunc.calculate_xint_bin(xbinmutacja[i]));
                funcx2[i] = myFunc.func(xrealmutacja[i]);
            }
        }

        private void calcElite()
        {
            int temp_index = Utility.myFate.Next(nValue);
            if (maxVal[0] > funcx2[temp_index])
            {
                xrealmutacja[temp_index] = maxVal[1];
                funcx2[temp_index] = maxVal[0];
            }
        }

        private void calcAvg()
        {
            double sum = 0;
            foreach (double num in funcx2)
            {
                sum += num;
            }

            avgVal = sum / funcx2.Length;
        }

        public double[] getXreal() { return xreal; }

        public string[] getXbin() { return xbin; }

        public string[] getXbin2() { return xbinmutacja; }

        public double[] getXreal2() { return xrealmutacja; }

        public double[] getMax() {  return maxVal; }
        public double[] getMin() {  return minVal; }
        public double getAvg() { return avgVal; }

        public double getMaxFunc() { return maxVal[0]; }
        public double getMinFunc() { return minVal[0]; }


    }
}
