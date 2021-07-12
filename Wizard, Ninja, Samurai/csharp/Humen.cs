using System;
using System.Collections.Generic;

namespace csharp
{
  public class Human 
  {
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public double health;

    public double Health
    {
      get { return health; }
      set { health = Health; }
    }

    public Human(string name)
    {
      Name = name;
      Strength = 3;
      Intelligence = 3;
      Dexterity = 3;
      health = 100;
    }

    public Human(string name, int str, int intel, int dex, int hp)
    {
      Name = name;
      Strength = str;
      Intelligence = intel;
      Dexterity = dex;
      health = hp;
    }

    public  double Attack(Human target)
    {
      double dmg = Strength * 3; 
      target.health -= dmg; 
      System.Console.WriteLine($"{Name} attacked by {target.Name} for {dmg} damage!");
      return target.health;
    }
  }
}