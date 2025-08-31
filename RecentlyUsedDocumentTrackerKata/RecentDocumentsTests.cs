namespace RecentlyUsedDocumentTrackerKata
{
    public class RecentDocumentsTests
    {
        [Fact]
        public void OpenDocumentShouldAddToRecentDocuments()
        {
            RecentDocuments recentDocuments = new(1);
            var docId = "test";

            recentDocuments.OpenDocument(docId);

            var docs = recentDocuments.GetRecentDocuments();

            Assert.Single(docs);
            Assert.Equal(docId, docs.Single());
        }

        [Fact]
        public void OpenDocumentShouldMoveToFrontOfRecentDocuments()
        {
            RecentDocuments recentDocuments = new(5);
            var docId1 = "test1";
            var docId2 = "test2";

            recentDocuments.OpenDocument(docId1);
            recentDocuments.OpenDocument(docId2);
            recentDocuments.OpenDocument(docId1);

            var docs = recentDocuments.GetRecentDocuments();

            Assert.Equal(2, docs.Count);
            Assert.Equal(docId1, docs.First());
            Assert.Equal(docId2, docs.Skip(1).First());
        }

        [Fact]
        public void RecentDocumentsShouldNotExceedCapacity()
        {
            RecentDocuments recentDocuments = new(2);
            var docId1 = "test1";
            var docId2 = "test2";
            var docId3 = "test3";

            recentDocuments.OpenDocument(docId1);
            recentDocuments.OpenDocument(docId2);
            recentDocuments.OpenDocument(docId3);

            var docs = recentDocuments.GetRecentDocuments().ToArray();

            Assert.Equal(2, docs.Count());
            Assert.Equal(docId3, docs[0]);
            Assert.Equal(docId2, docs[1]);
        }

        [Fact]
        public void NegativeCapacityThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>("capacity", () => new RecentDocuments(-1));
        }
    }
}