using System.Collections.Generic;
using chatapp_server.Users;

namespace chatapp_server.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository
    {
        void CreateUser(IUser user);
        void UpdateUser(IUser targetUser, IUser user);
        void DeleteUser(IUser user);
        void DeleteUser(int ID);
        void DeleteUser(string name);
        IUser GetUser(string name);
        IUser GetUser(int ID);
        List<IUser> GetUsers();

    }
}
