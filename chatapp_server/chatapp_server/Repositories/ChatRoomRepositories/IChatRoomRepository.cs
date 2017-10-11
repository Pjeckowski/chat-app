using System.Collections.Generic;
using chatapp_server.ChatRoom;

namespace chatapp_server.Repositories.ChatRoomRepositories
{
    public interface IChatRoomRepository : IRepository
    {
        void CreateRoom(string name);
        List<IChatRoom> GetChatRooms();
        IChatRoom GetChatRoom(int ID);
        void DeleteRoom(IChatRoom targetRoom);
        void DeleteRoom(int ID);
        void DeleteRoom(string name);
        void UpdateRoom(IChatRoom targetRoom, IChatRoom chatRoom);
        
    }
}
