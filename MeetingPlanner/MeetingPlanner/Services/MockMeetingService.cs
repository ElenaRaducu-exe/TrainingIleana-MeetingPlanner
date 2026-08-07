using MeetingPlanner.Classes;
using MeetingPlanner.Components.Pages;
using MeetingPlanner.Models;
using MeetingPlanner.Services.Contracts;

namespace MeetingPlanner.Services
{
    public class MockMeetingService : IMeetingService
    {
        private List<Meeting> meetingList =
            [
                new(){
                    Id = 1,
                    Title = "Meeting1", 
                    Date = @DateTime.Today.AddDays(2), 
                    ProjectID = 1,
                    Participants = new List<string>{"Ana", "Maria", "Irina" }
                }, 
                new(){
                    Id = 2,
                    Title = "Meeting2", 
                    Date = @DateTime.Today.AddDays(5), 
                    ProjectID = 1,
                    Participants = new List<string>{"Marian", "Stefania"}
                }, 
                new(){
                    Id = 3,
                    Title = "Meeting3", 
                    Date = @DateTime.Today, 
                    ProjectID = 2,
                    Participants = new List<string>{"Oana", "Ilinca", "Petru" }
                }, 
                new(){
                    Id = 4,
                    Title = "Meeting4", 
                    Date = @DateTime.Today.AddDays(8), 
                    ProjectID = 3,
                    Participants = new List<string>{"Ana", "Tudor", "Stefania", "Razvan"}
                }, 
                new(){
                    Id = 5,
                    Title = "Meeting5", 
                    Date = @DateTime.Today.AddDays(10), 
                    ProjectID = 4,
                    Participants = new List<string>{"Luca", "Maria", "Carmen" }
                }, 
                new(){
                    Id = 6,
                    Title = "Meeting6", 
                    Date = @DateTime.Today.AddDays(10), 
                    ProjectID = 2,
                    Participants = new List<string>{"Catalin", "Andrei" }
                }
            ];
        private readonly List<Project> projectList =
            [
                new(){
                    Id = 1,
                    Name = "Project 1",
                    Description = "Project 1 - MockMeetingService"
                }, 
                new(){
                    Id = 2,
                    Name = "Project 2",
                    Description = "Project 2 - MockMeetingService"
                }, 
                new(){
                    Id = 3,
                    Name = "Project 3",
                    Description = "Project 3 - MockMeetingService"
                }, 
                new(){
                    Id = 4,
                    Name = "Project 4",
                    Description = "Project 4 - MockMeetingService"
                }, 
                new(){
                    Id = 5,
                    Name = "Project 5",
                    Description = "Project 5 - MockMeetingService"
                } 
            ];

        public List<Project> GetProjects()
        {
            return projectList; 
        }
        public List<Meeting> GetMeetings()
        {
            return meetingList; 
        }

        public async Task AddMeetingAsync(Meeting meeting)
        {
            await Task.Run(() => 
            {
                if (meeting != null)
                { 
                    meetingList.Add(meeting);
                }
            });
        }

        public Task DeteleMeetingAsync(int id)
        {
            foreach (Meeting meeting in meetingList)
            {
                if (meeting.Id == id)
                {
                    meetingList.Remove(meeting);
                    break;
                }
            }

            return Task.CompletedTask;
        }

        public Task<Meeting?> GetMeetingByIdAsync(int id)
        {
            foreach (var meeting in meetingList)
            {
                if(id == meeting.Id)
                {
                    return Task.FromResult(meeting);
                }
            }

            return null;
        }

        public Task<List<Meeting>> GetMeetingsByProjectAsync(int projectId)
        {
            List<Meeting> meetingListProjectId = new List<Meeting>();

            foreach (var meetingItem in meetingList)
            {
                if (meetingItem.ProjectID == projectId)
                {
                    meetingListProjectId.Add(meetingItem);
                }
            }

            return Task.FromResult(meetingListProjectId);
        }

        public Task<List<Project>> GetProjectsAsync()
        {
            return Task.FromResult(projectList);
        }

        public Task UpdateMeetingAsync(Meeting meeting)
        {
            meeting.Title = String.Concat(meeting.Title + " - updated Title");

            return Task.CompletedTask;
        }

        public Task<List<Meeting>> GetMeetingsAsync()
        {
            return Task.FromResult(meetingList);
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return projectList.FirstOrDefault(x => x.Id == id);
        }

        public int GetLastMeetingID()
        {
            Meeting lastMeeting = meetingList[meetingList.Count - 1];
            return lastMeeting.Id; 
        }

        public async Task<List<MeetingSummary>> GetMeetingSummaries()
        {
            List<MeetingSummary> meetingSummaries = new List<MeetingSummary>();

            foreach(var meeting in meetingList)
            {
                Project prj = await GetProjectByIdAsync(meeting.ProjectID);
                MeetingSummary meetingSummary = new()
                {
                    Id = meeting.Id,
                    Title = meeting.Title,
                    Date = meeting.Date,
                    ProjectId = prj.Id,
                    ProjectName = prj.Name,
                    ProjectDescription = prj.Description,
                    Participants = meeting.Participants
                };

                meetingSummaries.Add(meetingSummary);
            }

            return meetingSummaries;
        }
    }
}
