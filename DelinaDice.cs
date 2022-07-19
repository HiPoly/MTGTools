using System.Collections.Generic;
using System;

public class DelinaDice
{
  static void Main(string[] args){
    bool rolling = true;
    int numberOfDice = 5;
    int currentRoll = 1;
    List<int> rollResults = new List<int>();
    int successCount = 0;
    //Counts the number of times you have rolled one or more dice
    int rollCount = 0;
    //Counts the total number of dice you have rolled
    int diceCount = 0;
    Random rnd = new Random();

    while (rolling){  
      //resets values from the previous roll
      bool success = false;
      currentRoll = 1;
      rollResults.Clear();
      //Adds to the counter of rolls of one or more dice
      rollCount++;
      while(currentRoll < numberOfDice + 1){
        rollResults.Add(rnd.Next(1, 20));
        Console.WriteLine("tick");
        currentRoll++;
        diceCount++;
      }
    foreach (int result in rollResults){
      if (result >= 15){
        success = true;
        }
      }
    
    if (success){
      successCount++;
      Console.WriteLine(String.Join(",", rollResults));
      Console.WriteLine("You get to roll again!");
      } 
    else if (!success){
        Console.WriteLine(String.Join(",", rollResults));
        Console.WriteLine("The forces of chaos do not favour you this time. Create " + successCount + 1 + " copies");
        Console.WriteLine($"You rolled {rollCount} dice with a total of {diceCount} dice");
      rolling = false;
      } 
    }
  }
}
