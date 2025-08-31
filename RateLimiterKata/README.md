CodeX offers an API that customers can use. To prevent abuse, the system needs tto rate limit users based on their subscription tier.

Each user is allowed a certain number of requests per minute, depending on their plan:

- Free: 10 requests/minute
- Pro: 100 requests/minute
- Enterprise: 1000 requests/minute

Implement a rate limiter.