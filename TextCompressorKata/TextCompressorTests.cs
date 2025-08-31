namespace TestCompressorKata
{
    public class TestCompressorTests
    {
        TextCompressor textCompressor = new();

        [Fact]
        public void CompressWithoutRepeatingCharactersShouldBeUnchanged()
        {
            var input = "abcd";
            var expectedOutput = "abcd";

            var result = textCompressor.Compress(input);

            Assert.Equal(expectedOutput, result);
        }

        [Theory]
        [InlineData("aaa", "a3")]
        [InlineData("abbb", "ab3")]
        [InlineData("aaabccc", "a3bc3")]
        public void RepeatedCharactersShouldBeReplacedWithCount(string input, string output)
        {
            var result = textCompressor.Compress(input);

            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData("a3", "aaa")]
        [InlineData("ab3", "abbb")]
        [InlineData("a3bc3", "aaabccc")]
        public void CharactersWithCountShouldBeReplacedWithRepeatedCharacters(string input, string output)
        {
            var result = textCompressor.Decompress(input);

            Assert.Equal(output, result);
        }

        [Theory]
        [InlineData("5")]
        public void NumberWithoutPrecedingLetterShouldThrowException(string input)
        {
            Assert.Throws<ArgumentException>(() => textCompressor.Decompress(input));
        }
    }
}