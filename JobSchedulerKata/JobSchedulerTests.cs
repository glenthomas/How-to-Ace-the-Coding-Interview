namespace JobSchedulerKata
{
    public class JobSchedulerTests
    {
        [Fact]
        public void AddJobShouldAddJobToQueue()
        {
            JobScheduler scheduler = new();
            var jobId = "test";

            scheduler.AddJob(jobId, 1);
            var result = scheduler.GetNextJob();

            Assert.Equal(jobId, result);
        }

        [Fact]
        public void HighestPriorityJobIsFirst()
        {
            JobScheduler scheduler = new();
            var jobId1 = "test1";
            var jobId2 = "test2";

            scheduler.AddJob(jobId1, 1);
            scheduler.AddJob(jobId2, 2);
            var result = scheduler.GetNextJob();

            Assert.Equal(jobId2, result);
        }

        [Fact]
        public void SamePriorityJobOrderIsPreserved()
        {
            JobScheduler scheduler = new();
            var jobId1 = "test1";
            var jobId2 = "test2";
            var jobId3 = "test3";

            scheduler.AddJob(jobId1, 1);
            scheduler.AddJob(jobId2, 2);
            scheduler.AddJob(jobId3, 2);
            var result = scheduler.GetNextJob();

            Assert.Equal(jobId2, result);
        }

        [Fact]
        public void GetNextJobRemovesFromQueue()
        {
            JobScheduler scheduler = new();
            var jobId1 = "test1";

            scheduler.AddJob(jobId1, 1);
            var result = scheduler.GetNextJob();

            Assert.Equal(jobId1, result);

            result = scheduler.GetNextJob();

            Assert.Null(result);
        }

        [Fact]
        public void PeekNextJobRetainsJobInQueue()
        {
            JobScheduler scheduler = new();
            var jobId1 = "test1";

            scheduler.AddJob(jobId1, 1);
            var result = scheduler.PeekNextJob();

            Assert.Equal(jobId1, result);

            result = scheduler.GetNextJob();

            Assert.Equal(jobId1, result);
        }
    }
}