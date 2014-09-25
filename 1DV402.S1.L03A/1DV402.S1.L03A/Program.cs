using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L03A
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    
                    int count = ReadInt("Ange antal löner: "); // kallar på readint med en prompt parameter

                    if (count < 2)
                    {
                        throw new Exception("Du måste mata in minst två löner för att kunna göra en beräkning!");
                    }
                    ProcessSalaries(count);
                  
                }
                catch (Exception ex) //hanterar även inmatning av tal som är för stora
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();   
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck tangent för en ny beräkning - ESC avslutar.");
                Console.ResetColor();
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
       
        static int ReadInt(string prompt) // Hanterar inmatning av användaren. En prompt sträng skickas med som parameter för att skriva ut ett meddelande till användaren.
        {
            
            while(true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    
                    
                    int amount = int.Parse(input);
                    return amount;
                    

                }
                catch(FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! {0} kan inte tolkas som ett heltal!", input);
                    Console.WriteLine();
                    Console.ResetColor();
                   
                }
                
            }
        }
        static void ProcessSalaries(int count)
        {
            //skapa en array av storleken count
            int[] antal = new int[count];
            

            Console.WriteLine("");
            //mata in x antal löner i array
            for (int i = 0; i < antal.Length; i++)
            {
                
                antal[i] = ReadInt(string.Format("Ange lön {0}: ", i + 1));
            }
            Console.WriteLine("");
            Console.WriteLine("--------------------------------");

            //klonar HELA "antal" arrayn till en ny array som heter "tempArray"
            int[] tempArray = (int[])antal.Clone();

            //sorterar elementen i tempArray
            Array.Sort(tempArray);

            //beräkna medianen
            if (count % 2 == 0)
            {
                int medianNumber1 = tempArray[tempArray.Length / 2 - 1];                        /// Beräkningar för om count är jämnt krävs då 2 tal kan vara de i mitten
                int medianNumber2 = tempArray[tempArray.Length / 2];
                Console.WriteLine("Medianlön: {0,20:C}", (medianNumber1 + medianNumber2) / 2);
                
            }
            else
            {
                int median = tempArray[tempArray.Length/2];                                    /// Annars är det ojämnt vilket lämnar 1 tal i mitten och 
                Console.WriteLine("Medianlön: {0,20:C}",median);
            }
            Console.WriteLine("Medellön: {0,21:C}", tempArray.Average());
            Console.WriteLine("Lönespridning: {0,16:C0}", tempArray.Max() - tempArray.Min());
            Console.WriteLine("--------------------------------");

            for (int i = 0; i < count; i++)  /// Skriver ut 3 rader med den osorterade arrayn "antal"
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine("");
                }

                Console.Write("{0,9}", antal[i]);
            }
        }

    }
}