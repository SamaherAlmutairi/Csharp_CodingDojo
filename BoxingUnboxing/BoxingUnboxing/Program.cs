using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {

List<object> list_ = new List<object>();
list_.Add(7);
list_.Add(28);
list_.Add(-1);
list_.Add(true);
list_.Add("char");

int sum=0;
for(int i=0;i < list_.Count; i++)
{
    Console.WriteLine(list_[i]);

if (list_[i] is int) {
    sum+=(int)list_[i];
}

}
    Console.WriteLine(sum);

    }
}
}
