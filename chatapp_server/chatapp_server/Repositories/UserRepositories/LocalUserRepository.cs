using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chatapp_server.Serializer;
using chatapp_server.Users;

namespace chatapp_server.Repositories.UserRepositories
{
    public class LocalUserRepository : IUserRepository
    {
        public List<IUser> UserList;
        private ISerializer Serializer;
        public LocalUserRepository(ISerializer serializer)
        {
            Serializer = serializer;
            UserList = LoadUserList() ?? new List<IUser>();
        }


        public void CreateUser(IUser user)
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
        }

        public void UpdateUser(IUser targetUser, IUser user)
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
        }

        public void DeleteUser(IUser user)
        {
            UserList.Remove(UserList.Find(oUser => oUser.Nickname == user.Nickname && oUser.Email == user.Email));
            SaveUserList();
        }

        public void DeleteUser(int ID)
        {
            UserList.Remove(UserList[ID]);
            SaveUserList();
        }

        public void DeleteUser(string nickname)
        {
            UserList.Remove(UserList.Find(oUser => oUser.Nickname == nickname));
            SaveUserList();
        }

        public IUser GetUser(string nickname)
        {
            return UserList.Find(oUser => oUser.Nickname == nickname);
        }

        public IUser GetUser(int ID)
        {
            return UserList[ID];
        }

        public List<IUser> GetUsers()
        {
            return UserList;
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
