namespace Core.Models.HealthCheck
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }

        public IEnumerable<HealthCheckItem> Checks { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
