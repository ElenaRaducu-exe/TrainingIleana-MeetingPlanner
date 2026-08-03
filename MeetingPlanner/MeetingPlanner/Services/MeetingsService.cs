using MeetingPlanner.Classes;

namespace MeetingPlanner.Services
{
    public class MeetingsService
    {
        private readonly List<MeetingItem> meetingList =
        [
            new(){
                Id = 1,
                MeetingTitle = "Meeting 1",
                Date = @DateTime.Today,
                ProjectId = 1
            },
            new(){
                Id = 2,
                MeetingTitle = "Meeting 2",
                Date = @DateTime.Today.AddDays(2),
                ProjectId = 2
            },
            new(){
                Id = 3,
                MeetingTitle = "Meeting 3",
                Date = @DateTime.Today.AddDays(4),
                ProjectId = 1
            },
            new(){
                Id = 4,
                MeetingTitle = "Meeting 4",
                Date = @DateTime.Today.AddDays(6),
                ProjectId = 3
            }
        ];

        public List<MeetingItem> getMeetings()
        {
            return meetingList;
        }

        public MeetingItem? GetMeetingCardByID(int searchId)
        {
            foreach (MeetingItem meetingItem in meetingList)
            {
                if (meetingItem.Id == searchId)
                {
                    return meetingItem;
                }
            }
            return null;
        }

        public List<MeetingItem> GetMeetingsByProjectId(int searchProjectId)
        {
            List<MeetingItem> meetingListProjectId = new List<MeetingItem>();

            foreach(var meetingItem in meetingList)
            {
                if(meetingItem.ProjectId == searchProjectId)
                {
                    meetingListProjectId.Add(meetingItem);
                }
            }

            return meetingListProjectId;
        }
        
    }
}
