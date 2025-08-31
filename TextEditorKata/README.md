CodeX is building a rich text editor for its document tools, and they want to support undo/redo functionality for user input.

Implement a TextEditor class with basic editing and undo/redo support.

```csharp
public class TextEditor
{
    public void Type(string text);
    public void Delete(int count);
    public void Undo();
    public void Redo();
    public string GetContent();
}
```

- Only two operations can be undone/redone: Type and Delete.
- Undo reverses the last operation.
- Redo applies the last undone operation.
- Typing or deleting after and undo clears the redo history.