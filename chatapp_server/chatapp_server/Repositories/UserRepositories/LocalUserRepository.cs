using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using chatapp_server.Serializer;
using chatapp_server.Users;

namespace chatapp_server.Repositories.UserRepositories
{
    public class LocalUserRepository : IUserRepository
    {
        public List<IUser> UserList;
        private ISerializer Serializer;
        private static Task completedTask = Task.FromResult(false);
        
        public static Task CompletedTask()
        {
            return completedTask;
        }

        public LocalUserRepository(ISerializer serializer)
        {
            Serializer = serializer;
            UserList = LoadUserList() ?? new List<IUser>();
        }


        public Task CreateUserAsync(IUser user)
        {
            if (null == UserList.Find(oUser => oUser.Nickname == user.Nickname || oUser.Email == user.Email))
            {
               UserList.Add(user);
               SaveUserList();
            }
            else
            {
                throw new ArgumentException("Nickname or email is already assignet to other user.");
            }
            return completedTask;
        }

        public Task UpdateUserAsync(IUser targetUser, IUser user)
        {
            IUser tUser = UserList.Find(oUser => oUser.Nickname == targetUser.Nickname && oUser.Email == targetUser.Email);
            if (tUser == null)
            {
                throw new ArgumentException("Target user not found.");
            }
            else
            {
                tUser = targetUser;
                SaveUserList();
            }
            return completedTask;
        }

        public Task DeleteUserAsync(IUser user)
        {
            UserList.Remove(UserList.Find(oUser => oUser.Nickname == user.Nickname && oUser.Email == user.Email));
            SaveUserList();
            return completedTask;
        }

        public Task DeleteUserAsync(int ID)
        {
            UserList.Remove(UserList[ID]);
            SaveUserList();
            return completedTask;
        }

        public Task DeleteUserAsync(string nickname)
        {
            UserList.Remove(UserList.Find(oUser => oUser.Nickname == nickname));
            SaveUserList();
            return completedTask;
        }

        public Task<IUser> GetUserAsync(string nickname)
        {
            return Task.FromResult(UserList.Find(oUser => oUser.Nickname == nickname));
        }

        public Task<IUser> GetUserAsync(int ID)
        {
            return Task.FromResult(UserList[ID]);
        }

        public Task<List<IUser>> GetUsersAsync()
        {
            return Task.FromResult(UserList);
        }

        private List<IUser> LoadUserList()
        {
            return (List<IUser>) Serializer.Deserialize(Properties.Settings.Default.UserList);
        }

        private void SaveUserList()
        {
            Properties.Settings.Default.UserList = Serializer.Serialize(UserList);
            Properties.Settings.Default.Save();
        }

    }
}
