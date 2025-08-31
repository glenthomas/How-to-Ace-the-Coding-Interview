namespace RecentlyUsedDocumentTrackerKata
{
    public class RecentDocuments
    {
        private readonly int capacity;
        private readonly LinkedList<string> docList = new();

        public RecentDocuments(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be positive", "capacity");
            }

            this.capacity = capacity;
        }

        public void OpenDocument(string docId)
        {
            if (docList.Contains(docId))
            {
                docList.Remove(docId);
            }
            docList.AddFirst(docId);
            if (docList.Count > capacity)
            {
                docList.RemoveLast();
            }
        }

        public List<string> GetRecentDocuments()
        {
            return docList.ToList();
        }
    }
}
