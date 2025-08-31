When CodeX receives a stream of text segments from multiple clients we want to avoid reprocessing identical text segments that arrive within a short window (e.g. 60 seconds).

The system should:

- Accept incoming segments with a unique segment ID and text.
- Return true if it's the first time we've seen this text in the last 60 seconds.
- Return false iof we've already processed the same text recently.
- Automatically remove entries from memory once they are older than 60 seconds.

Implement:

```csharp
public class DuplicateDetector
{
    public DuplicateDetector(TimeSpan window);
    public bool IsNewSegment(string text);
}
```

Requirements:

- Time-based eviction of entries.
- Must handle high-throughput efficiently.
- Must be O(1) average time complexity for both checking and inserting.
