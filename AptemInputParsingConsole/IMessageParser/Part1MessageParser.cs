using System.Text.RegularExpressions;


namespace AptemInputParsing
{
    public class Part1MessageParser : IMessageParser
    {
        public Dictionary<char, int> UpdateItems(string input)
        {
            Dictionary<char, int> resultingItems = [];

            foreach (string stack in input.Trim().Split(' '))
            {
                char itemIdentifier = Convert.ToChar(Regex.Match(stack, @"\w$").Value);
                int itemCount = stack.Length;

                resultingItems = MessageParserHelper.AddItems(resultingItems, itemIdentifier, itemCount);
            }

            return resultingItems;
        }
    }
}
