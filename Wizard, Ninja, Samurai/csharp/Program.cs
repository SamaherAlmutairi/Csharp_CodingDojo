using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
  public static void Main(string[] args)
        {
      Wizard w1 = new Wizard("Samaher");
      Ninja n1 = new Ninja("Noura");
      Samurai s1 = new Samurai("Rana");

      // Ninja attack and steal
      // n1.Steal(w1);
      // n1.Attack(w1);

      // // attack then heal
      // w1.Attack(n1);
      // w1.Heal(n1);

      // attack then midate
      s1.Attack(n1);
      s1.Meditate();
      


    }
    }

}

