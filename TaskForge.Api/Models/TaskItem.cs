namespace TaskForge.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int Priority { get; set; }
        public List<string> Tags { get; set; } = new();
        public DateTime? DueDate { get; set; }
    }
}