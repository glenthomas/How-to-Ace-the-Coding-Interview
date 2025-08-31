namespace DuplicateTextDetectorKata
{
    public class DuplicateDetector
    {
        private readonly TimeSpan window;
        private readonly Queue<(string text, DateTime timestamp)> previousTextQueue = new();
        private readonly HashSet<string> seenTexts = new();

        public DuplicateDetector(TimeSpan window)
        {
            this.window = window;
        }

        public bool IsNewSegment(string text)
        {
            DateTime now = DateTime.UtcNow;

            while (previousTextQueue.Count > 0 && now - previousTextQueue.Peek().timestamp > window)
            {
                var old = previousTextQueue.Dequeue();
                seenTexts.Remove(old.text);
            }

            if (seenTexts.Contains(text))
            {
                return false;
            }

            previousTextQueue.Enqueue((text, now));
            seenTexts.Add(text);
            return true;
        }
    }
}
