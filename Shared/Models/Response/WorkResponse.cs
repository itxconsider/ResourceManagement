namespace Shared.Models.Response
{
    public class WorkResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }
        public string Description { get; set; }
    }
}
