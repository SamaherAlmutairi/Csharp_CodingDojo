using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
  public static void Main(string[] args)
        {
            Human Samaher = new Human("Samaher"); 
            // Human Noura = new Human("Noura"); 
            Human Ahmed = new Human("Ahmed", 4, 6, 15, 130);
            Ahmed.Attack(Samaher);

        }

        class Human
{
    // Fields for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int health;
    public Human(string Name)
        {
            this.Name = Name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
            public Human(string Name, int Strength, int Intelligence, int Dexterity, int health)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Intelligence = Intelligence;
            this.Dexterity = Dexterity;
            this.health = health;
        }
     
    public Human Attack(Human target)
    {
         target.health -= 5 * Strength;
            Console.WriteLine($"Health of {target.Name} is {target.health}");
            return this;
    }
}
    }
}