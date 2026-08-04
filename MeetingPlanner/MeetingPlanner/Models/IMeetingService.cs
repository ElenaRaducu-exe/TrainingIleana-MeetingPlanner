namespace MeetingPlanner.Models
{
    public interface IMeetingService
    {
        Task<List<Project>> GetProjectsAsync(); 
        Task<List<Meeting>> GetMeetingsByProjectAsync(int projectId);
        Task<Meeting?> GetMeetingByIdAsync(int id);
        Task AddMeetingAsync(Meeting meeting); 
        Task UpdateMeetingAsync(Meeting meeting);
        Task DeteleMeetingAsync(int id); 
    }
}
