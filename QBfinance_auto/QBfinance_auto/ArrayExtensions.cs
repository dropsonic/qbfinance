using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBfinance_auto
{
    public static class ArrayExtensions
    {
        //Fisher–Yates/Durstenfeld shuffle
        public static void Shuffle<T>(this IList<T> array)
        {
            var r = new Random(DateTime.Now.Millisecond);
            for (int i = array.Count; i > 1; i--)
            {
                int j = r.Next(i);
                T tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
        }
    }
}
