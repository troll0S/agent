using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UtilityNamespace;

namespace BasicMathsNamespace
{
    class BasicMaths
    {
        double a, b, d;
        int l;
        Random random = new Random();
        public BasicMaths(double a, double b, double d)
        {
            this.a = a;
            this.b = b;
            this.d = d;
            this.l = calculate_l();


        }
        public int getL()
        {
            return l;
        }

        private int calculate_l()
        {
            double temp = ((this.b - this.a) / this.d + 1);
            double l = Math.Ceiling(Math.Log(temp) / Math.Log(2));
            return (int)l;
        }

        public double rand_xreal()
        {

            return Math.Floor((random.NextDouble() * (this.b - this.a) + this.a) / d) * d;
        }

        public int calculate_xint(double xreal)
        {
            int xint = (int)Math.Ceiling((1 / (this.b - this.a) * (xreal - this.a) * (Math.Pow(2, this.l) - 1)));
            return xint;
        }

        public double calculate_xreal(int xint)
        {
            double xreal = Math.Floor((xint * (this.b - this.a) * (1 / (Math.Pow(2, this.l) - 1)) + this.a) / d) * d;
            return xreal;
        }
        public string calculate_xbin(int xint)
        {

            string xbin = "";

            xbin = Convert.ToString(xint, 2).PadLeft(l, '0');
            return xbin;

        }
        public int calculate_xint_bin(string xbin)
        {
            int xint = 0;
            int power = xbin.Length - 1;

            foreach (char digit in xbin)
            {
                if (digit == '1')
                {
                    xint += (int)Math.Pow(2, power);
                }
                power--;
            }

            return xint;
        }
        public double func(double x)
        {
            double result;
            result = (x - Math.Floor(x)) * (Math.Cos(20 * Math.PI * x) - Math.Sin(x));
            return result;
        }
        public double min_in_table(double[] tab)
        {
            double min = tab[0];
            for( int i = 1; i < tab.Length; ++i ) 
            {
                if(tab[i] < min)
                {
                    min = tab[i];
                }
            }
            return min;
        }

        public double max_in_table(double[] tab)
        {
            double max = tab[0];
            for (int i = 1; i < tab.Length; ++i)
            {
                if (tab[i] > max)
                {
                    max = tab[i];
                }
            }
            return max;
        }

        public double func_gx_max(double x,double fin)
        {
            double result;
            result = func(x)- fin + d;
            return result;
        }
       /* public double func_gx_min(double x)
        {
            double result;
            result = (func(x) + 2) * (-1) + d;
            return result;
        }*/
        public void childs(int pc,ref string a,ref string b)
        {
            string firstChild,secondChild;
            firstChild = a.Substring(0,pc)+b.Substring(pc);
            secondChild = b.Substring(0,pc)+a.Substring(pc);
            a = firstChild;
            b = secondChild;
        }


    }
}
