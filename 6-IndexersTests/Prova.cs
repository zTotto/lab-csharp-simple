using System;
using System.Collections.Generic;
using System.Text;

namespace Indexers
{
    class Prova
    {
        static void Main(string[] args)
        {
            var prova = new Map2D<int, int, int>();
            prova[1, 1] = 1;
            prova[2, 2] = 2;
            prova[3, 3] = 3;
            prova[4, 4] = 4;
            prova[1, 5] = 2;
            Console.WriteLine($"{prova}" + Environment.NewLine);
            foreach (var item in prova.GetRow(1))
            {
            Console.WriteLine("[1, " + item.Item1 + "] => " + item.Item2);
            }
        }
    }
}
