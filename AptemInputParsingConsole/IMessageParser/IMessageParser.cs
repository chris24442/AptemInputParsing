using System.Text.RegularExpressions;

namespace AptemInputParsing
{
    public interface IMessageParser
    {
        Dictionary<char, int> UpdateItems(string input);
    }
}