namespace MeetingPlanner.Services
{
    public class MeetingStateService
    {
        public int? SelectedProjectId {  get; set; }
        public string? CurrentMeetingTitle {  get; set; }

        // evenimentul care notifica componentele ca starea s-a modificat 
        public event Action? OnChange; 

        public void SetProject(int id)
        {
            this.SelectedProjectId = id;
            
            OnChange?.Invoke(); // declanseaza OnChange
        }

        public void ClearSelection()
        {
            this.SelectedProjectId = null;
            this.CurrentMeetingTitle = null;

            OnChange?.Invoke();
        }
    }
}
