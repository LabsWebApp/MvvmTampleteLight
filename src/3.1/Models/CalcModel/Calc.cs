using System;
using System.Linq;

namespace CalcModel
{
    public static class Calc
    {
        public static int Sum(params int[] values) => values.Aggregate((x, y) => x + y);
    }
}
