using System;
using System.Collections.Generic;

namespace csharp
{
  public class Wizard : Human
  {
   public int Intelligence; 
      public double health;

  public  Wizard(string name): base (name)
  {
     Intelligence = 25; 
       health = 50; 
    }



    // public Wizard (string name) : base (name)
    // {
      
    // }
    // public Wizard (int Intelligence,int health ) 
    // {
    //   this.Intelligence = Intelligence; 
    //   this.health = health; 
    // }
    
    public   double Attack(Human target)
    {
      double damage = Intelligence * 5; 
      target.health -= damage; 
      System.Console.WriteLine(Name+" attacked "+target.Name+" the damage "+ damage+" !");
      health += damage; 
      return target.health; 
    }

    public double Heal (Human target)
    {
      double heals  = Intelligence * 10; 
      target.health += heals; 
      System.Console.WriteLine(Name+"  healed " +target.Name+" by "+ heals+" health has become "+target.Health );
      return target.health;
    }
  }
}