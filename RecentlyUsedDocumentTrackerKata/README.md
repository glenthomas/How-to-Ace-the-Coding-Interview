CodeX wants to build a feature for its document dashboard:
When a user logs in, they should see their N most recently translated documents, sorted by most recent first.

The system needs to support:

- Fast lookup (so you don't duplicate entries for the same document).
- Fast insertion/update (when a document is opened again, it should move to the top).
- Automatic removal when the list exceeds N entries.

This is essentially a "Most Recently Used" list - similar to an LRU cache, but for user-visible history.

Implement:

```csharp
public class RecentDocuments
{
    public RecentDocuments(int capacity);
    public void OpenDocument(string docId);
    public List<string> GetRecentDocuments();
}
```

OpenDocument should:
- If the doc is already in the list, move it to the front.
- If it's new and capacity is full, remove the least recent one (at the end).

GetRecentDocuments should return documents from most recent to least.
