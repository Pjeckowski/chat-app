using System.Collections.Generic;
using System.Threading.Tasks;
using chatapp_server.Users;

namespace chatapp_server.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository
    {
        Task CreateUserAsync(IUser user);
        Task UpdateUserAsync(IUser targetUser, IUser user);
        Task DeleteUserAsync(IUser user);
        Task DeleteUserAsync(int ID);
        Task DeleteUserAsync(string name);
        Task<IUser> GetUserAsync(string name);
        Task<IUser> GetUserAsync(int ID);
        Task<List<IUser>> GetUsersAsync();

    }
}
