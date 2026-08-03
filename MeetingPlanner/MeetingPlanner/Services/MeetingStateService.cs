namespace MeetingPlanner.Services
{
    public class MeetingStateService
    {
        public int? SelectedProject {  get; set; }
        public string? CurrentMeetingTitle {  get; set; }

        public event Action? OnChange; 

        public void SetProject(int id)
        {
            this.SelectedProject = id;

            OnChange?.Invoke();
        }

        public void ClearSelection()
        {
            this.SelectedProject = null;
            this.CurrentMeetingTitle = null;

            OnChange?.Invoke();
        }
    }
}
