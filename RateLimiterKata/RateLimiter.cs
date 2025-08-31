namespace RateLimiterKata
{
    internal class RateLimiter
    {
        private readonly Dictionary<string, int> _planLimits = new Dictionary<string, int>
        {
            {"Free", 10},
            {"Pro", 100},
            {"Enterprise", 1000}
        };

        private Dictionary<string, string> _userPlans;


        private readonly Dictionary<string, Queue<Request>> _userRequests = new();

        private const int WindowSize = 60;

        public RateLimiter(Dictionary<string, string> userPlans)
        {
            _userPlans = userPlans;
        }

        internal bool RateLimitReached(Request request)
        {
            if (!_userPlans.ContainsKey(request.ApiKey))
            {
                throw new ArgumentException("Unknown API key");
            }

            var userPlan = _userPlans[request.ApiKey];
            var planLimit = _planLimits[userPlan];

            if (!_userRequests.ContainsKey(request.ApiKey))
            {
                _userRequests.Add(request.ApiKey, new Queue<Request>());
            }

            Queue<Request> requestQueue = _userRequests[request.ApiKey];

            while (requestQueue.Count > 0 && request.RequestTime.Subtract(requestQueue.Peek().RequestTime).Seconds >= WindowSize)
            {
                requestQueue.Dequeue();
            }

            if (requestQueue.Count < planLimit)
            {
                requestQueue.Enqueue(request);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}