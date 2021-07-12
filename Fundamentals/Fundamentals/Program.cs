using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=0;
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}
        
for (int i = 1; i <= 100; i++)
{
    if (i%3==0 || i%5==0)
{
    Console.WriteLine(i);
}

        }
while (n < 10) 
    if (n%3==0)
{
    Console.WriteLine("Fizz");
}
else if(n%5==0){

    Console.WriteLine("Buzz");
}
else if(n%3==0 && n%5==0){
    Console.WriteLine("FizzBuzz");
}
    }
    }
}
