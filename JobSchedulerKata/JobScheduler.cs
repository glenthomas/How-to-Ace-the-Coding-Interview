namespace JobSchedulerKata
{
    internal class JobScheduler
    {
        SortedDictionary<int, Queue<string>> jobQueues = new();

        public void AddJob(string jobId, int priority)
        {
            if (!jobQueues.ContainsKey(priority))
            {
                jobQueues.Add(priority, new Queue<string>());
            }
            jobQueues[priority].Enqueue(jobId);
        }

        public string GetNextJob()
        {
            if (!jobQueues.Any())
            {
                return null;
            }

            int highestPriority = jobQueues.Keys.Max();
            var queue = jobQueues[highestPriority];
            var job = queue.Dequeue();

            if (queue.Count == 0)
            {
                jobQueues.Remove(highestPriority);
            }

            return job;
        }

        public string PeekNextJob()
        {
            var queue = GetHighestPriorityQueue();
            var job = queue.Peek();
            return job;
        }

        private Queue<string> GetHighestPriorityQueue()
        {
            int highestPriority = jobQueues.Keys.Max();
            var queue = jobQueues[highestPriority];
            return queue;
        }
    }
}
