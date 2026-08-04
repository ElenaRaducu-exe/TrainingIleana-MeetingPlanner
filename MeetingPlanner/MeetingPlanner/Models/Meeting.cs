namespace MeetingPlanner.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProjectID { get; set; }
        public List<string>? Participants { get; set; } 
    }
}
