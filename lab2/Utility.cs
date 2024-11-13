using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
