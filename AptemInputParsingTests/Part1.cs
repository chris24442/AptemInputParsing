using AptemInputParsing;

namespace AptemInputParsingTests
{
    [TestClass]
    // TODO: Add more tests 
    public class Part1
    {
        [TestMethod]
        public void ProvidedExample()
        {
            var input = "aaaa eeeeee bb c aa ccc d";
            var expectedResult = "6a 2b 4c 1d 6e";

            Warehouse warehouse = new(input ?? "");

            Assert.AreEqual(expectedResult, warehouse.ToString());
        }

        [TestMethod]
        public void FurtherExample1()
        {
            var input = "eeeeee bb c aa ccc d aa ";
            var expectedResult = "4a 2b 4c 1d 6e";

            Warehouse warehouse = new(input ?? "");

            Assert.AreEqual(expectedResult, warehouse.ToString());
        }
    }
}