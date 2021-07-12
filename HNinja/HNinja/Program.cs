using System;
using System.Collections.Generic;

namespace csharp
{
    class Program
    {
  public static void Main(string[] args)
        {
            
      Ninja ss = new Ninja();
      Buffet servingf = new Buffet();
      while (ss.IsFull == false)
      {
        ss.Eat(servingf.Serve());
              System.Console.WriteLine($"Calorieintake is {ss.CalorieAmount}");
      }
    
    }
        
        }
class Food
{
    public string Name;
    public int Calories;
    // Foods can be Spicy and/or Sweet
    public bool IsSpicy; 
    public bool IsSweet; 
    // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food (string Name, int Calories, bool IsSpicy, bool IsSweet)
    {
        this.Name = Name; 
        this.Calories = Calories; 
        this.IsSpicy = IsSpicy; 
        this.IsSweet = IsSweet; 
    }
}
class Buffet
{
    public List<Food> Menu;
     
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Example", 400, false, false),
            new Food("Pizza", 800, true, true)

        };
    }
     Random r = new Random();
            public Food Serve()
    {
        return Menu[r.Next(Menu.Count)];

    }
}
class Ninja
{
    private int calorieIntake;
        public int CalorieAmount 
        {
 get 
      {
        return calorieIntake;
      }
        }

    public List<Food> FoodHistory;
        // add a constructor
       public Ninja() 
    {
      calorieIntake = 0; 
      FoodHistory = new List<Food>() { 
    
      };
    }
     
    // add a public "getter" property called "IsFull"
     public bool IsFull
    {
      get {
        bool isfull = false; 
        if (calorieIntake > 1000)
        {
          isfull = true;
        }
        return isfull;
      }
    }
     
    // build out the Eat method
    public void Eat(Food item)
    {
        
      calorieIntake += item.Calories;
      FoodHistory.Add(item);
      System.Console.WriteLine($"Food : {item.Name}, Spicy: {item.IsSpicy}, Sweet: {item.IsSweet}");
    }
}

    }

