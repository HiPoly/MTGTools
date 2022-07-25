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
        //DiceCounters
        int numberOfDice = 1;
        int currentRoll = 1;
        List<int> rollResults = new List<int>();
        int rollCount = 0;
        int successCount = 1;
        int diceCount = 0;
        int drawCount = 0;
        bool Barbarian = true;
        Random rnd = new Random();
        int wyllStart = 0;
        //Get Target
        Console.WriteLine("Delina Target:\n 1 - Wyll, Blade of Frontiers\n 2 - Pixie Guide\n 3 - Farideh, Devil\'s Chosen");
        string targetInput = Console.ReadLine();
        int target = Convert.ToInt32(targetInput);
        if (targetInput == "1")
        {
            Wyll = true; Console.WriteLine("Targeting Wyll.\n");
            Console.WriteLine("What is Wyll's current power?\n");
            string wyllInput = Console.ReadLine();
            wyllStart = Convert.ToInt32(wyllInput);
        }
        if (targetInput == "2") { Pixie = true; Console.WriteLine("Targeting Pixie.\n"); }
        if (targetInput == "3") { Farideh = true; Console.WriteLine("Targeting Farideh.\n"); }
        else if (target <= 0 || target >= 4)
        {
        }
        //Get Advantage Sources
        Console.WriteLine("\nTotal sources of advantage?: \n(Wyll, Pixie Guide, Barbarian Class, Krark's Thumb etc.)");
        string advantageInput = Console.ReadLine();
        int advantageSources = Convert.ToInt32(advantageInput);
        Console.WriteLine($"Rolling with " + (advantageSources + 1) + " dice.");
        while (rolling)
        {
            //set starting values before new roll
            numberOfDice = 1 + advantageSources;
            bool success = false;
            currentRoll = 1;
            rollResults.Clear();
            rollCount++;
            while (currentRoll < numberOfDice + 1)
            {
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
                if (Wyll)
                {
                    int wyllCopies = rollCount;
                    int wyllPower = wyllStart + wyllCopies;
                    while (wyllCopies > 0)
                    {
                        wyllPower += wyllCopies;
                        wyllCopies--;
                    }
                    Console.WriteLine($"With that many copies you can dish out {wyllPower} points of damage");
                }
                if (Barbarian)
                {
                    Console.WriteLine($"Your rage flows across the battlefield. {rollCount} of your creatures gain +2/+0 and menace until end of turn!");
                }
                if (Farideh)
                {
                    Console.WriteLine($"Fill that hand with cards instead of dice. You get to draw {drawCount} cards!");
                }
                rolling = false;
                break; //Stop the Rolling!
            }
            else if (success)
            {
                successCount++;
                Console.WriteLine(String.Join(",", rollResults));
                Console.WriteLine("You get to roll again!\n");
                if (Wyll || Pixie)
                {
                    advantageSources++;
                    if (advantageSources % 10 == 0)
                    {
                        Console.WriteLine($"Whoa there, you've hit {advantageSources} successes!");
                        rolling = false;
                    }
                }
                Console.WriteLine("Now rolling with " + (advantageSources + 1) + " dice!");
                Thread.Sleep(1000);
            }
        }
    }
}
