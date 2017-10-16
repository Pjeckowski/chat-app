using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using chatapp_server.ChatRoom;
using chatapp_server.Serializer;

namespace chatapp_server.Repositories.ChatRoomRepositories
{
    public class LocalChatRoomRepository : IChatRoomRepository
    {
        private readonly List<IChatRoom> ChatRoomList;
        private ISerializer Serializer;

        private static readonly Task completedTask = Task.FromResult(false);

        public static Task CompletedTask()
        {
            return completedTask;
        }

        public LocalChatRoomRepository(ISerializer serializer)
        {
            Serializer = serializer;
            ChatRoomList = LoadChatRoomList();
            if (null == ChatRoomList)
            {
                ChatRoomList = new List<IChatRoom>();
                ChatRoomList.Add(new ChatRoom.ChatRoom("Default"));
            }
        }

        public Task CreateRoom(string name)
        {
            if (!ChatRoomList.Exists(oChatRoom => oChatRoom.Name == name))
            {
                ChatRoomList.Add(new ChatRoom.ChatRoom(name));
                SaveChatRoomList();
            }
            else
            {
                throw new ArgumentException("ChatRoom with this name already exists");
            }
            return completedTask;
        }

        public Task<List<IChatRoom>> GetChatRooms()
        {
            return Task.FromResult(ChatRoomList);
        }

        public Task<IChatRoom> GetChatRoom(string name)
        {
            return Task.FromResult(ChatRoomList.Find(oChatRoom => oChatRoom.Name == name));
        }

        public Task<IChatRoom> GetChatRoom(int ID)
        {
            return Task.FromResult(ChatRoomList[ID]);
        }

        public Task DeleteRoom(IChatRoom targetRoom)
        {
            ChatRoomList.Remove(ChatRoomList.Find(oChatRoom => oChatRoom.Name == targetRoom.Name));
            SaveChatRoomList();
            return completedTask;
        }

        public Task DeleteRoom(int ID)
        {
            ChatRoomList.Remove(ChatRoomList[ID]);
            SaveChatRoomList();
            return completedTask;
        }

        public Task DeleteRoom(string name)
        {
            ChatRoomList.Remove(ChatRoomList.Find(oChatRoom => oChatRoom.Name == name));
            SaveChatRoomList();
            return completedTask;
        }

        public Task UpdateRoom(IChatRoom targetRoom, IChatRoom chatRoom)
        {
            IChatRoom tRoom = ChatRoomList.Find(oChatRoom => oChatRoom.Name == targetRoom.Name);
            tRoom.Name = chatRoom.Name;
            tRoom.Password = chatRoom.Password;
            SaveChatRoomList();
            return completedTask;
        }

        private void SaveChatRoomList()
        {
            Properties.Settings.Default.ChatRoomList = Serializer.Serialize(ChatRoomList);
            Properties.Settings.Default.Save();
        }

        private List<IChatRoom> LoadChatRoomList()
        {
            return (List<IChatRoom>) Serializer.Deserialize(Properties.Settings.Default.ChatRoomList);
        }
    }
}
