namespace MeetingPlanner.Classes
{
    public class MeetingItem
    {
        public int Id { get; set; }
        public string MeetingTitle { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
    }
}
