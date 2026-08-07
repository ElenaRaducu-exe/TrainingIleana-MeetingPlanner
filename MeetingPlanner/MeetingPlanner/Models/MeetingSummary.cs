namespace MeetingPlanner.Models
{
    public class MeetingSummary
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string>? Participants { get; set; }
    }
}
