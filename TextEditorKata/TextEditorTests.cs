namespace TextEditorKata
{
    public class TextEditorTests
    {
        TextEditor textEditor = new();

        [Fact]
        public void TypeShouldAddText()
        {
            textEditor.Type("hello world.");
            textEditor.Type(" hello world.");

            var result = textEditor.GetContent();

            Assert.Equal("hello world. hello world.", result);
        }

        [Fact]
        public void DeleteShouldRemoveText()
        {
            textEditor.Type("hello world.");
            textEditor.Delete(7);

            var result = textEditor.GetContent();

            Assert.Equal("hello", result);
        }

        [Fact]
        public void UndoTypeShouldRemoveText()
        {
            textEditor.Type("hello world.");
            textEditor.Type(" hello world.");
            textEditor.Undo();

            var result = textEditor.GetContent();

            Assert.Equal("hello world.", result);
        }

        [Fact]
        public void UndoDeleteShouldRemoveText()
        {
            textEditor.Type("hello world.");
            textEditor.Delete(7);
            textEditor.Undo();

            var result = textEditor.GetContent();

            Assert.Equal("hello world.", result);
        }

        [Fact]
        public void RedoUndoneTypeShouldAppendText()
        {
            textEditor.Type("hello world.");
            textEditor.Type(" hello world.");
            textEditor.Undo();
            textEditor.Redo();

            var result = textEditor.GetContent();

            Assert.Equal("hello world. hello world.", result);
        }

        [Fact]
        public void RedoUndoDeleteShouldRemoveText()
        {
            textEditor.Type("hello world.");
            textEditor.Delete(7);
            textEditor.Undo();
            textEditor.Redo();

            var result = textEditor.GetContent();

            Assert.Equal("hello", result);
        }
    }
}