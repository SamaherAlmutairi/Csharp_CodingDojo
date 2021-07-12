using System;
using System.Collections.Generic;
namespace Iron_Ninja
{
    class Program
    {
        static void Main(string[] args)
        {
            // In your Program's Main method: instantiate a Buffet, a SweetTooth, and a SpiceHound.
            Buffet newBuffet = new Buffet ();
            SweetTooth ciso = new SweetTooth ();
            SpiceHound lobo = new SpiceHound ();
            while (ciso.IsFull == false) {
                ciso.Consume (newBuffet.Serve ());
            }
            Console.WriteLine ($"Calorie intake is {ciso.CalorieAmount}. Ninja is full and cannot consume.");

            Console.WriteLine ("**********");

            while (lobo.IsFull == false) {
                lobo.Consume (newBuffet.Serve ());
            }
            Console.WriteLine ($"Calorie intake is {lobo.CalorieAmount}. Ninja is full and cannot consume.");

            Console.WriteLine ("**********");

            if (ciso.ConsumptionHistory.Count > lobo.ConsumptionHistory.Count) {
                Console.WriteLine ($"The Sweet Tooth has consumed the most buffet items with {ciso.ConsumptionHistory.Count} items consumed.");
            } else if (ciso.ConsumptionHistory.Count < lobo.ConsumptionHistory.Count) {
                Console.WriteLine ($"The Spice Hound has consumed the most buffet items with {lobo.ConsumptionHistory.Count} items consumed.");
            } else {
                Console.WriteLine ($"The Sweet Tooth and Spice Hound have consumed an equal amount of buffet items with {lobo.ConsumptionHistory.Count} items consumed.");
            }  
                  }
    }
}
