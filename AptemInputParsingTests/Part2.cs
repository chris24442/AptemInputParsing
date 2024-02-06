using AptemInputParsing;

namespace AptemInputParsingTests
{
    [TestClass]
    // TODO: Add more tests with edge cases
    public class Part2
    {
        [TestMethod]
        public void ProvidedExample()
        {
            // TODO : this answer is wrong, right?
            var input = "#p2# 4a 4b 7c 2a 5d 2a 6d 1e 2d";
            var expectedResult = "9a 4b 7c 13d 1e";

            var output = CountingProgram.CountItems(input);

            Assert.AreEqual(expectedResult, output);
        }

        [TestMethod]
        public void FurtherExample1()
        {
            var input = "#p2# 4a 4b 7c 2a 5d 2a 6d 1e 2d";
            var expectedResult = "8a 4b 7c 13d 1e";

            var output = CountingProgram.CountItems(input);

            Assert.AreEqual(expectedResult, output);
        }

        [TestMethod]
        public void FurtherExample2()
        {
            var input = "#p2# 2a 5d 2a 6d 1e 1d 4a 4b 2c";
            var expectedResult = "8a 4b 2c 12d 1e";

            var output = CountingProgram.CountItems(input);

            Assert.AreEqual(expectedResult, output);
        }

    }
}