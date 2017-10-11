namespace chatapp_server.Users
{
    /// <summary>
    /// Object that ll contain User's ID, Nickname, Password, Email, Room penalties Etc.
    /// </summary>
    public class User : IUser
    {

        public uint ID { get; private set; }

        public string Nickname { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

    }
}
