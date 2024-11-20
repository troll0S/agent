using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class ZestawDanych
    {
        public double pk { get; set; }
        public double pn { get; set; }
        public double favg { get; set; }
        public int N { get; set; }
        public int T { get; set; }

        public ZestawDanych(double pk, double pn, double favg, int N, int T)
        {
            this.pk = pk;
            this.pn = pn;
            this.favg = favg;
            this.N = N;
            this.T = T;
        }
    }
}
