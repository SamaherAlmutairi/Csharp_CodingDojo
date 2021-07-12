using System;
using System.Collections.Generic;

namespace csharp
{
  public class Ninja : Human
  {
    public Ninja (string Name) : base (Name)
    {
      Dexterity  = 175; 
    }

    public  double  Attack (Human target)
    {
      Random rand = new Random(); 
      double per = rand.Next(0, 100);
      double ratio=per/100;
      double damage ; 
      if (ratio < 0.20)
      {
        damage = 5 * Dexterity; 
      }
      else 
      {
       damage = 10 + (Dexterity * 5);
      }
          System.Console.WriteLine("Rate "+ratio);

      target.health -= damage; 
      System.Console.WriteLine(Name+" attacked "+ target.Name +" for  "+damage+"  damage!");
      return target.health;
    }

    public double Steal (Human target)
    {
      target.health -= 5; 
      Health += 5; 
      System.Console.WriteLine(Name+" has stolen 5 amount from " +target.Name );
      System.Console.WriteLine(target.Name +" her/his health "+target.Health);
      return target.health;
    }
  }
}