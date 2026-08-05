using System.ComponentModel.DataAnnotations;

namespace MeetingPlanner.Classes
{
    public class NewMeetingModel
    {
        [Display(Prompt = "Enter the meeting title")]
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required!")]
        public DateTime Date {  get; set; } = DateTime.Today;

        [Display(Prompt = "Choose the project ID for the meeting")]
        [Required(ErrorMessage = "Project's ID is required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a project id from dropdown!")]
        public int ProjectID { get; set; }

        [Display(Prompt = "Enter comma-separated names for participants")]
        [Required(ErrorMessage = "At least one participant is required!")]
        public string Participants { get; set; } = string.Empty;


        public List<string> ConvertToList()
        {
            List<string> participantsList = new();

            if (string.IsNullOrWhiteSpace(Participants))
            {
                participantsList.Clear();
            }
            else
            {
                participantsList = Participants.Split(',').ToList();
            }

            return participantsList;
        }
    }
}
