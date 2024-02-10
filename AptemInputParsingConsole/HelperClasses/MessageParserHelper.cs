using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptemInputParsing
{
    static class MessageParserHelper
    {
        public static Dictionary<char, int> AddItems(Dictionary<char, int> resultingItems, char itemIdentifier, int itemCount)
        {
            resultingItems.TryGetValue(itemIdentifier, out int runningCount);
            resultingItems[itemIdentifier] = runningCount + itemCount;
            return resultingItems;
        }
    }
}
