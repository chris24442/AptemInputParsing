using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AptemInputParsing
{
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
        // TODO: TryParse here would be more robust
        public static int ItemCount(this string stack) =>
            Convert.ToInt32(Regex.Match(stack, @"^\d+").Value);

        public static char ItemIdentifier(this string stack) =>
            Convert.ToChar(Regex.Match(stack, @"\w$").Value);

        public static bool IsPart2Message(this string stack) =>
            Regex.Match(stack, @"^#p2# .+$").Success;
    }
}
