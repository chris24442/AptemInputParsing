using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptemInputParsingClasses
{
    public static class AptemInputParsingClass
    {
        static void CountItems(string message)
        {
            // Initialize a dictionary to store the counts of each item
            Dictionary<char, int> itemCounts = new Dictionary<char, int>();

            // Iterate through each character in the message
            foreach (char character in message)
            {
                // Check if the character is a valid item (a letter)
                if (char.IsLetter(character))
                {
                    // Update the count in the dictionary
                    if (itemCounts.ContainsKey(character))
                    {
                        itemCounts[character]++;
                    }
                    else
                    {
                        itemCounts[character] = 1;
                    }
                }
            }

            // Print the results
            foreach (var item in itemCounts)
            {
                Console.Write($"{item.Value}{item.Key} ");
            }
        }
    }
}
