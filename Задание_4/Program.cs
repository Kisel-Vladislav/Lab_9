using System;
using System.Collections.Generic;

namespace Задание_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 1; i <= 1000; i++)
            {
                int com = 0;
                for (int j = 0; Math.Pow(j, 3) <= i; j++)
                {
                    for (int k = 0; Math.Pow(k, 3) <= i; k++)
                    {
                        for (int l = 0; Math.Pow(l, 3) <= i; l++)
                        {
                            if (Math.Pow(j, 3) + Math.Pow(k, 3) + Math.Pow(l, 3) == i)
                            {
                                com++;
                                dic[i] = com;
                            }
                        }
                    }
                }
            }
            
            foreach (var item in dic)
            {
                if(item.Value > 2)
                Console.Write(@"{0,5}--{1,-5}|",item.Key,item.Value);
            }
            Console.WriteLine();
        }
        //static void N(int x = 0,int y = 0, int z = 0, int n = 2)
        //{
        //    if (Math.Pow(x, 3) + Math.Pow(y, 3) + Math.Pow(z, 3) > n)
        //        return;
        //    N(x+1, y, z,n);
        //    N(x, y + 1, z, n);
        //    N(x, y, z + 1, n);
        //    if (Math.Pow(x,3) + Math.Pow(y, 3) + Math.Pow(z, 3)  == n)
        //        Console.WriteLine($"{x} - {y} - {z} ");
        //}
    }
}
