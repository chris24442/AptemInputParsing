namespace AptemInputParsing
{
    public class CountingProgramConsole
    {
        private static void Main()
        {
            Console.Write("Enter the input stock message: ");
            string userInput = Console.ReadLine() ?? "";

            // Create the appropriate message parser
            IMessageParser messageParser = MessageParserFactory.CreateMessageParser(userInput);

            // Pass the messageParser instance to the Warehouse constructor
            Warehouse warehouse = new(userInput, messageParser);

            Console.WriteLine(warehouse.ToString());
        }
    }
}