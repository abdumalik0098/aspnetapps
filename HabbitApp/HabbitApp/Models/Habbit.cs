namespace HabbitApp.Models
{
    public class Habbit
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Trigger { get; set; }
        public int Duration { get; set; }
        public int Timer { get; set; }
        public string? Reward { get; set; }

    }

}
