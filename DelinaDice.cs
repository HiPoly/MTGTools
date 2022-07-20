using System.Collections.Generic;
using System;
using System.Threading;

public class DelinaDice
{
    static void Main(string[] args)
    {
        //Target Bools
        bool Wyll = false;
        bool Pixie = false;
        bool Farideh = false;
        bool rolling = true;
        int numberOfDice = 1;
        int currentRoll = 1;
        List<int> rollResults = new List<int>();
        int successCount = 1;
        //Counts the number of times you have rolled one or more dice
        int rollCount = 0;
        //Counts the total number of dice you have rolled
        int diceCount = 0;
        int drawCount = 0;
        bool Barbarian = false;
        Random rnd = new Random();
      //Input Vars
      Console.WriteLine("Delina Target:\n 1 - Wyll\n 2 - Pixie Guide\n 3 - Farideh, Devil\'s Chosen'");
      string input = Console.ReadLine();
      //Convert input to Boolean for Target Creature
      if (input == "1") {Wyll = true; Console.WriteLine("Targeting Wyll.\n");}
      if (input == "2") {Pixie = true; Console.WriteLine("Targeting Pixie.\n");}
      if (input == "3") {Farideh = true; Console.WriteLine("Targeting Farideh.\n");}
      
      Console.WriteLine("Total sources of advantage?: \n(Wyll, Pixie Guide, Barbarian Class, Krark's Thumb etc.)");
      string advantageInput = Console.ReadLine();
      int advantageSources = Convert.ToInt32(advantageInput);
      Console.WriteLine($"Rolling with " + (advantageSources + 1) + " dice.");
      
        while (rolling){
            //resets values from the previous roll
            numberOfDice = 1 + advantageSources;
            bool success = false;
            currentRoll = 1;
            rollResults.Clear();
            //Adds to the counter of rolls of one or more dice
            rollCount++;
            while (currentRoll < numberOfDice + 1){
                rollResults.Add(rnd.Next(1, 20));
                currentRoll++;
                diceCount++;
            }
            foreach (int result in rollResults)
            {
                if (result >= 15)
                {
                    success = true;
                    if (Farideh && result >= 10) drawCount++;
                    break;
                }
                else success = false;
            }
            if (!success)
            {
                Console.WriteLine(String.Join(",", rollResults));
                Console.WriteLine("The forces of chaos do not favour you this time. Create " + successCount + " copies\n");
                Console.WriteLine($"You rolled {rollCount} times with a total of {diceCount} dice");
                if (Barbarian){
                  Console.WriteLine($"Your rage flows across the battlefield. {rollCount} of your creatures gain +2/+0 and menace until end of turn!");
                }
                rolling = false;
                break; //Stop the Rolling!
            }
            else if (success)
            {
                successCount++;
                Console.WriteLine(String.Join(",", rollResults));
                Console.WriteLine("You get to roll again!\n");
                if (Wyll || Pixie) {
                  advantageSources++;
                  if (advantageSources >= 10){
                    Console.WriteLine("Whoa there, are you sure you want to keep rolling?");
                    Console.ReadLine();
                    rolling = false;
                  }
                }
                Console.WriteLine("Now rolling with " + (advantageSources + 1) +" dice!");
                Thread.Sleep(1000);
            }
        }
    }
}
