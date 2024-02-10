using System.Text.RegularExpressions;

namespace AptemInputParsing
{
    public static class MessageParserFactory
    {
        public static IMessageParser CreateMessageParser(string input)
        {
            if (IsPart2MessageType(input))
            {
                return new Part2MessageParser();
            }
            else
            {
                return new Part1MessageParser();
            }
        }

        private static bool IsPart2MessageType(string input) =>
            Regex.Match(input, @"^#p2# .+$").Success;
    }
}
