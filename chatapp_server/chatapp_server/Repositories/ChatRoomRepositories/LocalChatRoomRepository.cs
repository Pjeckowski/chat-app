using System;
using System.Collections.Generic;
using chatapp_server.ChatRoom;
using chatapp_server.Serializer;

namespace chatapp_server.Repositories.ChatRoomRepositories
{
    public class LocalChatRoomRepository : IChatRoomRepository
    {
        public List<IChatRoom> ChatRoomList { get; private set; }
        private ISerializer Serializer;

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

        public void CreateRoom(string name)
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
        }

        public List<IChatRoom> GetChatRooms()
        {
            return ChatRoomList;
        }

        public IChatRoom GetChatRoom(string name)
        {
            return ChatRoomList.Find(oChatRoom => oChatRoom.Name == name);
        }

        public IChatRoom GetChatRoom(int ID)
        {
            return ChatRoomList[ID];
        }

        public void DeleteRoom(IChatRoom targetRoom)
        {
            ChatRoomList.Remove(ChatRoomList.Find(oChatRoom => oChatRoom.Name == targetRoom.Name));
            SaveChatRoomList();
        }

        public void DeleteRoom(int ID)
        {
            ChatRoomList.Remove(ChatRoomList[ID]);
            SaveChatRoomList();
        }

        public void DeleteRoom(string name)
        {
            ChatRoomList.Remove(ChatRoomList.Find(oChatRoom => oChatRoom.Name == name));
            SaveChatRoomList();
        }

        public void UpdateRoom(IChatRoom targetRoom, IChatRoom chatRoom)
        {
            IChatRoom tRoom = ChatRoomList.Find(oChatRoom => oChatRoom.Name == targetRoom.Name);
            tRoom.Name = chatRoom.Name;
            tRoom.Password = chatRoom.Password;
            SaveChatRoomList();
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
