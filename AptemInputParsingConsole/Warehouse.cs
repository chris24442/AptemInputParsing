using System.Text;

namespace AptemInputParsing
{
    public class Warehouse
    {
        readonly Dictionary<char, int> ItemsInWarehouse = [];
        private readonly IMessageParser _messageParser;

        public Warehouse(string input, IMessageParser messageParser)
        {
            _messageParser = messageParser;

            ItemsInWarehouse = _messageParser.UpdateItems(input);
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