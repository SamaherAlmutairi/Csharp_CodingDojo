using System; 
using System.Collections.Generic;

namespace csharp
{
  public class Samurai : Human 
  {
    public Samurai (string name) : base (name)
    {
      health = 200; 
    }

    public  double Attack(Human target)
    {
      base.Attack(target);
      if (target.health < 50) 
      {
        target.health = 0; 
      }
        System.Console.WriteLine(Name+" attacked "+target.Name+" his/her health become "+target.health);

      return target.health;
    }

    public double Meditate() 
    {
      double midate=200;
      health = midate; 
      System.Console.WriteLine(Name+" Samurai back to full health "+ health);
      return health; 
    }
  }
}