using MeetingPlanner.Classes;

namespace MeetingPlanner.Services
{
    public class ProjectsService
    {
        private readonly List<ProjectItem> ProjectList =
        [
            new(){
                ProjectId = 1,
                ProjectName = "Project 1",
                ProjectColor = "#27EBF5"
            },
            new(){
                ProjectId = 2,
                ProjectName = "Project 2",
                ProjectColor = "#27EBF5"
            },
            new(){
                ProjectId = 3,
                ProjectName = "Project 3",
                ProjectColor = "#27EBF5"
            },
            new(){
                ProjectId = 4,
                ProjectName = "Project 4",
                ProjectColor = "#27EBF5"
            }
        ];

        public List<ProjectItem> getProjects()
        {
            return ProjectList;
        }

        public ProjectItem? GetProjectById(int searchId)
        {
            foreach (var item in ProjectList)
            {
                if (item.ProjectId == searchId)
                    return item;
            }
            return null; 
        }
    }
}
