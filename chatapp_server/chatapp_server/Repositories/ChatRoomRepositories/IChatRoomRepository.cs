using System.Collections.Generic;
using System.Threading.Tasks;
using chatapp_server.ChatRoom;

namespace chatapp_server.Repositories.ChatRoomRepositories
{
    public interface IChatRoomRepository : IRepository
    {
        Task CreateRoom(string name);
        Task<List<IChatRoom>> GetChatRooms();
        Task<IChatRoom> GetChatRoom(int ID);
        Task DeleteRoom(IChatRoom targetRoom);
        Task DeleteRoom(int ID);
        Task DeleteRoom(string name);
        Task UpdateRoom(IChatRoom targetRoom, IChatRoom chatRoom);  
    }
}
