using AptemInputParsing;
using System;
using System.Text;

namespace AptemInputParsing
{
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
}