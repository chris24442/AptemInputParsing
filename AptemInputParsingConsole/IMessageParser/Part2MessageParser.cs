using System.Text.RegularExpressions;

namespace AptemInputParsing
{

    public class Part2MessageParser : IMessageParser
    {
        readonly int lengthOfPart2Label = 4;

        public Dictionary<char, int> UpdateItems(string input)
        {
            Dictionary<char, int> resultingItems = [];

            foreach (string stack in input.Remove(0, lengthOfPart2Label).Trim().Split(' '))
            {
                char itemIdentifier = Convert.ToChar(Regex.Match(stack, @"\w$").Value);
                int itemCount = Convert.ToInt32(Regex.Match(stack, @"^\d+").Value);

                resultingItems = MessageParserHelper.AddItems(resultingItems, itemIdentifier, itemCount);
            }

            return resultingItems;
        }
    }
}