using System.Text;
using System.Text.RegularExpressions;

namespace AptemInputParsing
{
    public class CountingProgramConsole
    {
        private static void Main()
        {
            Console.Write("Enter the input stock message: ");
            string userInput = Console.ReadLine() ?? "";

            // TODO: Check valid input?

            Warehouse warehouse = new(userInput);

            Console.WriteLine(warehouse.ToString());
        }
    }
}