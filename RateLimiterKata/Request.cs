namespace RateLimiterKata
{
    internal struct Request
    {
        public DateTimeOffset RequestTime { get; }
        public string ApiKey { get; }

        public Request(long timestamp, string apiKey)
        {
            RequestTime = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            ApiKey = apiKey;
        }
    }
}