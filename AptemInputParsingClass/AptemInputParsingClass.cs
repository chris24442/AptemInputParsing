using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptemInputParsing
{
    public class AptemInputParsingClass
    {

        static void Main()
        {
            Console.Write("Enter a message: ");
            string userInput = Console.ReadLine();

            CountItems(userInput);
        }


        public static void CountItems(string message)
        {
            Console.WriteLine("Test");
        }
    }
}
