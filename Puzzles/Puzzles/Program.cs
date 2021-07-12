using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
  public static void Main(string[] args)
        {
    Random r = new Random();
            RandomArray(r);
            TossCoin(r);
            TossMultipleCoins(5, r);
            ShufflList( r);
        }
        public static int[] RandomArray(Random r)
        {
            int[] arr = new int[10];
            int sum = 0;
            int min = 5;
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                arr[i] = r.Next(5, 26);
                sum += arr[i];
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Sum: {sum}");
            return arr;
        }

        public static string TossCoin(Random r)
        {
            string result = "";
            Console.WriteLine("Tossing a Coin");
            int re = r.Next(0, 2);
            if (re == 0)
            {
                result = "Tails";
            }
            else
            {
                result = "Heads";
            }
            Console.WriteLine(result);
            return result;
        }
        public static double TossMultipleCoins(int num, Random r)
        {
            int head = 0;
            int tail = 0;
            for (int i = 0; i < num; i++)
            {
                string coinToss = TossCoin(r);
                if (coinToss == "Tails")
                {
                    tail++;
                }
                else 
                {
                    head++;
                }
                Console.WriteLine($"{coinToss}, tails: {tail} , heads: {head}");
            }
            double rate = (double)head / num;
            Console.WriteLine(rate);
            return rate;
        }
        public static string[] ShufflList( Random r)
        {
    string[] rnames = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            for (int i = 0; i < rnames.Length; i++)
            {
                int rand = r.Next(0, rnames.Length-1);
                string temp = rnames[i];
                rnames[i] = rnames[rand];
                rnames[rand] = temp;
            }
            for (int i = 0; i < rnames.Length; i++)
            {
                Console.WriteLine(rnames[i]);
            }
            return rnames;
        }   
    }
}