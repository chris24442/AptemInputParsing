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

    public class Warehouse
    {
        readonly Dictionary<char, int> ItemsInWarehouse = [];

        public Warehouse(string input)
        {
            int messageType = InputParser.IdentifyMessageType(input);
            input = InputParser.TrimMessage(input, messageType);
            ItemsInWarehouse = InputParser.UpdateItems(input, messageType);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (KeyValuePair<char, int> entry in ItemsInWarehouse
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value))
            {
                stringBuilder.Append(' ').Append(entry.Value).Append(entry.Key);
            }

            // TODO: There must be a better way to avoid this trim.
            return stringBuilder.ToString().Trim();

        }

    }

    public static class InputParser
    {
        internal static int IdentifyMessageType(string input)
        {
            if (input.IsPart2Message())
                return 2;
            else
                return 1;
        }

        internal static string TrimMessage(string input, int messageType)
        {
            switch (messageType)
            {
                case 2:
                    int lengthOfPart2Label = 4;
                    return input.Remove(0, lengthOfPart2Label).Trim(' ');

                case 1:
                    return input.Trim(' ');

                default:
                    return input;
            }
        }

        internal static Dictionary<char, int> UpdateItems(string input, int messageType)
        {
            Dictionary<char, int> resultingItems = [];
            switch (messageType)
            {
                case 2:
                    foreach (string stack in input.Split(' '))
                    {
                        char itemIdentifier = stack.ItemIdentifier();
                        int itemCount = stack.ItemCount();

                        resultingItems.TryGetValue(itemIdentifier, out int runningCount);
                        resultingItems[itemIdentifier] = runningCount + itemCount;
                    }
                    break;

                case 1:
                    foreach (string stack in input.Split(' '))
                    {
                        char itemIdentifier = stack.ItemIdentifier();
                        int itemCount = stack.Length;

                        resultingItems.TryGetValue(itemIdentifier, out int runningCount);
                        resultingItems[itemIdentifier] = runningCount + itemCount;
                    }
                    break;


                default:
                    throw new NotImplementedException();
            }

            return resultingItems;
        }
    }

    static class StringExtensions
    {
        public static bool IsValidFormatPart1(this string stack) =>
            Regex.Match(stack, @"^[A-z]+$").Success;

        public static bool IsValidFormatPart2(this string stack) =>
            Regex.Match(stack, @"^\d+\w$").Success;

        // TODO: TryParse here would be more robust
        public static int ItemCount(this string stack) =>
            Convert.ToInt32(Regex.Match(stack, @"^\d+").Value);

        public static char ItemIdentifier(this string stack) =>
            Convert.ToChar(Regex.Match(stack, @"\w$").Value);

        public static bool IsStackAllTheSame(this string stack)
        {
            char firstChar = stack[0];

            foreach (char c in stack)
                if (c != firstChar)
                    return false;

            return true;
        }

        public static bool IsPart2Message(this string stack) =>
            Regex.Match(stack, @"^#p2# .+$").Success;
    }
}