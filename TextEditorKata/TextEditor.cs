using System.Text;

namespace TextEditorKata
{
    internal class TextEditor
    {
        private StringBuilder _stringBuilder = new();
        private Stack<IAction> _undoStack = new();
        private Stack<IAction> _redoStack = new();

        internal void Delete(int characterCount)
        {
            var currentString = _stringBuilder.ToString();
            var stringLength = currentString.Length;
            _stringBuilder.Remove(stringLength - characterCount, characterCount);
            _undoStack.Push(new DeleteAction(currentString.Substring(stringLength - characterCount, characterCount)));
            _redoStack.Clear();
        }

        internal object GetContent()
        {
            return _stringBuilder.ToString();
        }

        internal void Redo()
        {
            _redoStack.Pop().Redo(this);
        }

        internal void Type(string text)
        {
            _stringBuilder.Append(text);
            _undoStack.Push(new TypeAction(text));
            _redoStack.Clear();
        }

        internal void Undo()
        {
            IAction undoAction;
            if (!_undoStack.TryPop(out undoAction))
            {
                return;
            }

            undoAction.Undo(this);
            _redoStack.Push(undoAction);
        }
    }

    internal interface IAction
    {
        void Undo(TextEditor textEditor);
        void Redo(TextEditor textEditor);
    }

    internal class TypeAction : IAction
    {
        private readonly string text;

        public TypeAction(string text)
        {
            this.text = text;
        }

        public void Undo(TextEditor textEditor)
        {
            textEditor.Delete(text.Length);
        }

        public void Redo(TextEditor textEditor)
        {
            textEditor.Type(text);
        }
    }

    internal class DeleteAction : IAction
    {
        private readonly string textDeleted;

        public DeleteAction(string textDeleted)
        {
            this.textDeleted = textDeleted;
        }

        public void Redo(TextEditor textEditor)
        {
            textEditor.Delete(textDeleted.Length);
        }

        public void Undo(TextEditor textEditor)
        {
            textEditor.Type(textDeleted);
        }
    }
}