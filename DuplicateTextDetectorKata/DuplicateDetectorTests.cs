namespace DuplicateTextDetectorKata
{
    public class DuplicateDetectorTests
    {
        [Fact]
        public void ShouldReturnTrueForNewSegment()
        {
            DuplicateDetector detector = new(TimeSpan.FromMinutes(1));

            var result = detector.IsNewSegment("hello world");

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalseForRepeatedSegment()
        {
            DuplicateDetector detector = new(TimeSpan.FromMinutes(1));
            string text = "hello world";

            detector.IsNewSegment(text);
            var result = detector.IsNewSegment(text);

            Assert.False(result);
        }
    }
}