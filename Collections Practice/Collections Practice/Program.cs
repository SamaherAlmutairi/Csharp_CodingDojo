using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
    int[] arr = {0,1, 2, 3, 4, 5,6,7,8,9};
Console.WriteLine(arr[0]);    
Console.WriteLine(arr[1]);    
Console.WriteLine(arr[2]);    
Console.WriteLine(arr[3]);    
Console.WriteLine(arr[4]);
Console.WriteLine(arr[5]);    
Console.WriteLine(arr[6]);    
Console.WriteLine(arr[7]);    
Console.WriteLine(arr[8]);    
Console.WriteLine(arr[9]);    

    string [] names = {"Tim", "Martin", "Nikki",  "Sara"};
Console.WriteLine(names[0]);    
Console.WriteLine(names[1]);    
Console.WriteLine(names[2]);    
Console.WriteLine(names[3]);

bool[] barr = {true,false,true,false,true,false,true,false,true,false};
// Console.WriteLine(barr[0]);    
// Console.WriteLine(barr[1]);    
// Console.WriteLine(barr[2]);    
// Console.WriteLine(barr[3]);    
// Console.WriteLine(barr[4]);
// Console.WriteLine(barr[5]);    
// Console.WriteLine(barr[6]);    
// Console.WriteLine(barr[7]);    
// Console.WriteLine(barr[8]);    
// Console.WriteLine(barr[9]); 

 foreach (bool res in barr) {
         Console.WriteLine(res);
    }

List<string> flavors  = new List<string>();
flavors.Add("Vanilla ");
flavors.Add("Dark Chocolate");
flavors.Add("Strawberry");
flavors.Add("Milk Chocolate");
flavors.Add("Toffee");
Console.WriteLine($"We have {flavors.Count} flavors.");
Console.WriteLine(flavors [2]); 
flavors.Remove("Strawberry");
Console.WriteLine($"We have {flavors.Count} flavors.");

Dictionary<string,string> flaor_name = new Dictionary<string,string>();

flaor_name.Add("Nikki", "Vanilla");
flaor_name.Add("Martin", "Dark Chocolate");
flaor_name.Add("Tim", "Milk Chocolate");
flaor_name.Add("Sara", "Toffee");
// Console.WriteLine("Instructor Profile");
// Console.WriteLine("Name - " + flaor_name["Name"]);
// Console.WriteLine("From - " + flaor_name["Location"]);
// Console.WriteLine("Favorite Language - " + flaor_name["Language"]);
foreach (var list in flaor_name)
{
    Console.WriteLine(list.Key + " - " + list.Value);
}

    }
}
}
