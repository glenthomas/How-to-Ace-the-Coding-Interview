**Scenario:**

A language translation system can’t translate directly between all language pairs.
Sometimes it needs to chain translations through intermediate languages.

For example:
- English → Japanese might require going through German (EN → DE → JA).
- We want to find the shortest path (fewest hops) from a source to a target language.

You need to:
- Accept a list of supported direct translations.
- Given a source and target language, find the shortest route (if any).
- Return the path as a list of language codes.

**Implement:**

```csharp
public class TranslationRouter
{
    public TranslationRouter(List<(string from, string to)> supportedPairs);
    public List<string> FindShortestPath(string from, string to);
}
```

**Requirements:**

1. Treat translation links as bidirectional (if EN → DE is supported, DE → EN is also supported).
2. If no path exists, return an empty list.
3. Use an efficient algorithm for shortest path.
