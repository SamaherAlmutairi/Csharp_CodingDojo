using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
  public static void Main(string[] args)
        {

        }
public static void PrintNumbers()
{
for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
}
public static void PrintOdds()
{
for (int i = 1; i < 256; i++)
            {
                if(i%2!=0){
                Console.WriteLine(i);
                }
            }}
public static void PrintSum()
{
    int sum = 0;
             for (int i = 1; i < 256; i++)
            {
                sum += i;
                Console.WriteLine("New Number: " + i + " The Sum : "+ sum);
            }  
}
public static void LoopArray(int[] numbers)
{
    // Write a function that would iterate through each item of the given integer array and 
    // print each value to the console. 
}
public static int FindMax(int[] numbers)
{
      int max = numbers[0];
            foreach (int i in numbers)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
}
public static int  GetAverage(int[] numbers)
{
    int sum = 0;
            foreach (int i in numbers)
            {
                sum += i;
            }

            return sum/(numbers.Length);

}
public static void OddArray()
{
    int sum = 0;
            int[] arr = new int[255];
            foreach (int i in arr)
            {
                sum++;
                arr[i] = sum;
                Console.WriteLine(arr[i]);
            }

}
public static int GreaterThanY(int[] numbers, int y)
{
     int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > y)
                {
                    sum++;
                }
            }
            return sum;
}
public static void SquareArrayValues(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i]*numbers[i];
            }
}
public static void EliminateNegatives(int[] numbers)
{
     for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
}
public static void MinMaxAverage(int[] numbers)
{
            int sum = 0;
            int average  = 0;
            int max = numbers[0];
            int min = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
                if(numbers[i] > max)
                {
                    max = numbers[i];
                }

                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            average   = sum / numbers.Length;
            Console.WriteLine("The Max: " + max );
            Console.WriteLine( "The Min: " + min );
            Console.WriteLine("The Average " + average );

}
public static void ShiftValues(int[] numbers)
{
    int[] arr = new int[numbers.Length];
            int counter = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                arr[counter] = numbers[i];
                counter++;
            }
            arr[arr.Length-1] = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                System.Console.WriteLine(arr[j]);
            }

}
public static object[] NumToString(object[] numbers)
{
for (var i = 0; i < numbers.Length; i++)
            {
                if ((int)numbers[i] < 0)
                {
                    numbers[i] = "Dojo";
                }
                Console.WriteLine(numbers[i]);
            }
            return numbers;

}


    }
}

