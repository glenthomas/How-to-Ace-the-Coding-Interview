namespace RateLimiterKata
{
    public class RateLimiterTests
    {
        [Fact]
        public void FreeUserAllowedTenRequestsPerMinute()
        {
            var apiKey = "test-free";
            var userPlans = new Dictionary<string, string>
            {
                { apiKey, "Free" }
            };
            var rateLimiter = new RateLimiter(userPlans);
            List<Request> allowedRequests = Enumerable.Range(1, 10).Select(x => new Request(x, apiKey)).ToList();
            foreach (var request in allowedRequests)
            {
                Assert.True(rateLimiter.RateLimitReached(request));
            }

            Assert.False(rateLimiter.RateLimitReached(new Request(11, apiKey)));
        }

        [Fact]
        public void ProUserAllowedOneHundredRequestsPerMinute()
        {
            var apiKey = "test-pro";
            var userPlans = new Dictionary<string, string>
            {
                { apiKey, "Pro" }
            };
            var rateLimiter = new RateLimiter(userPlans);
            List<Request> allowedRequests = Enumerable.Range(1, 100).Select(x => new Request(x, apiKey)).ToList();
            foreach (var request in allowedRequests)
            {
                Assert.True(rateLimiter.RateLimitReached(request));
            }

            Assert.False(rateLimiter.RateLimitReached(new Request(101, apiKey)));
        }

        [Fact]
        public void EnterpriseUserAllowedOneThousandRequestsPerMinute()
        {
            var apiKey = "test-enterprise";
            var userPlans = new Dictionary<string, string>
            {
                { apiKey, "Enterprise" }
            };
            var rateLimiter = new RateLimiter(userPlans);
            List<Request> allowedRequests = Enumerable.Range(1, 1000).Select(x => new Request(x, apiKey)).ToList();
            foreach (var request in allowedRequests)
            {
                Assert.True(rateLimiter.RateLimitReached(request));
            }

            Assert.False(rateLimiter.RateLimitReached(new Request(1001, apiKey)));
        }
    }
}