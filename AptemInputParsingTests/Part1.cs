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

            var output = CountingProgram.CountItems(input);

            Assert.AreEqual(expectedResult, output);
        }

        [TestMethod]
        public void FurtherExample1()
        {
            var input = "eeeeee bb c aa ccc d aa ";
            var expectedResult = "4a 2b 4c 1d 6e";

            var output = CountingProgram.CountItems(input);

            Assert.AreEqual(expectedResult, output);
        }
    }
}