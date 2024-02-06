using System.Text;
using System.Text.RegularExpressions;

namespace AptemInputParsing
{
    public class CountingProgram
    {
        // TODO: I've assumed a console input and output was required. (Not a string calling a function and popping up an output console).
        private static void Main(string[] args)
        {
            Console.Write("Enter the input stock message: ");
            string userInput = Console.ReadLine();
            Console.WriteLine(CountItems(userInput ?? ""));
        }

        public static string CountItems(string userInput)
        {
            if (string.IsNullOrEmpty(userInput)) throw new Exception("User input was not expected to be blank / null");

            var ResultingItemCounts = new Dictionary<char, int>();

            if (userInput.IsPart2Message())
                Part2StackParser(userInput, ref ResultingItemCounts);
            else
                Part1StackParser(userInput, ref ResultingItemCounts);

            // TODO: Check this sorted output assumption, there can be some refactoring to simplify if this is true.
            return ResultingMessage(ResultingItemCounts
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value));
        }

        private static void Part2StackParser(string userInput, ref Dictionary<char, int> resultingItemCounts)
        {
            int lengthOfPart2Label = 4;
            foreach (string stack in userInput.Remove(0, lengthOfPart2Label).Trim(' ').Split(' '))
            {
                if (!stack.IsValidFormatPart2())
                    throw new Exception("This stack is an invalid format " + stack);

                UpdateResultingItemCount(resultingItemCounts, stack.ItemIdentifier(), stack.ItemCount());
            }
        }

        private static void Part1StackParser(string userInput, ref Dictionary<char, int> resultingItemCounts)
        {
            foreach (string stack in userInput.Trim(' ').Split(' '))
            {
                if (!stack.IsValidFormatPart1() || !stack.IsStackAllTheSame())
                    throw new Exception("This stack is an invalid format " + stack);

                UpdateResultingItemCount(resultingItemCounts, stack.ItemIdentifier(), stack.Length);
            }
        }

        private static void UpdateResultingItemCount(Dictionary<char, int> resultingItemCounts, char itemIdentifier, int itemCount)
        {
            resultingItemCounts.TryGetValue(itemIdentifier, out int runningCount);
            resultingItemCounts[itemIdentifier] = runningCount + itemCount;
        }

        private static string ResultingMessage(Dictionary<char, int> runningItemCounts)
        {
            var stringBuilder = new StringBuilder();
            foreach (KeyValuePair<char, int> entry in runningItemCounts)
                stringBuilder.Append(' ').Append(entry.Value).Append(entry.Key);

            // TODO: There must be a better way to avoid this trim.
            return stringBuilder.ToString().Trim(); 
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