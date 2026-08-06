using MeetingPlanner.Classes;

namespace MeetingPlanner.Services
{
    public class InMemoryAuthService
    {
        private List<AppUser> users = [
                new(){
                    Username = "Ileana", 
                    Password = "parola1", 
                    Role = "admin"
                }, 
                new(){
                    Username = "Victor", 
                    Password = "parola2", 
                    Role = "user"
                }, 
                new(){
                    Username = "Maria", 
                    Password = "parola3", 
                    Role = "reader"
                } 
            ];

        private AppUser? currentUser = new();

        public AppUser? Login(string username, string password)
        {
            foreach (var user in users)
            {
                if(user.Username == username && user.Password == password)
                {
                    currentUser = user;
                    return user; 
                }
            }
            return null; 
        }

        public AppUser? GetCurrentUser()
        {
            return currentUser;
        }

        public void Logout()
        {
            currentUser = null;
        }

        public List<AppUser> GetUsers()
        {
            return users;
        }

        public void AddUser(AppUser user)
        {
            users.Add(user);
        }

        public void ModifyUserDetails(AppUser user, string newRole)
        {
            if(newRole != null)
            {
                user.Role = newRole;
            }
        }
    }
}
