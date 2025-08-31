CodeX procsses jobs for different customer tiers:

- Enterprise: highest priority
- Pro: medium priority
- Free: lowest priority

You need to design a scheduler that:

- Accepts incoming jobs with an ID and a priority.
- Always processes the highest priority job first.
- Within the same priority, jobs are processed in the order thaty they arrived (FIFO).
- Support checking the next job without removing it.

Implement:

```chsarp
internal class JobScheduler
{
    public void AddJob(string jobId, int priority);
    public string GetNextJob();
    public string PeekNextJob();
}
```

- Multiple jobs may have the same priority. Must preserve order of arrival within a priority.
- Must run in O(log n) or better for job insertion/removal.
- Priority can be assuemd to be 1 (low) to 3 (high), but should be easy to extend.
