using System;
using chatapp_server.Network;
using chatapp_server.Request;

namespace chatapp_server
{
    public class RequestFactory
    {
        public IRequest GetRequest(User CallingUser, IPacket packet)
        {
            switch (packet.Header)
            {
                case RequestType.LOGIN:
                    return new LoginRequest(packet.Body);

                case RequestType.KICK:
                    return null;

                case RequestType.MESSAGE:
                    return null;

                case RequestType.PRIVATE_MESSAGE:
                    return null;

                default:
                case RequestType.CORRUPTED:
                    throw new ArgumentException();
            }   
        }

        public string KRGetUserName(string CommandBody)
        {
            if (IsKickRequest(CommandBody))
            {
                int UserNameSI = CommandBody.IndexOf(KickRequestCommand) + KickRequestCommand.Length;
                int UserNameLenght = CommandBody.Length - KickRequestCommand.Length;

                string UserName = CommandBody.Substring(UserNameSI, UserNameLenght);

                return UserName;
            }
            return null;
        }

        private bool IsLoginRequest(string CommandBody)
        {
            if (0 == CommandBody.IndexOf(LoginRequestCommand))
                return true;
            return false;
        }

        public string[] LRGetUserInfo(string CommandBody, RequestInfo RequestInfo)
        {
            int PSindex;
            if (-1 != (PSindex = CommandBody.IndexOf(RequestInfo.PasswordSeparator)))
            {
                string UserName, UserPassword;

                int SI = CommandBody.IndexOf(LoginRequestCommand) + LoginRequestCommand.Length;
                int Length = PSindex - SI;

                UserName = CommandBody.Substring(SI, Length);

                SI = CommandBody.IndexOf(RequestInfo.PasswordSeparator) + RequestInfo.PasswordSeparator.Length;
                Length = CommandBody.Length - SI;

                UserPassword = CommandBody.Substring(SI, Length);

                return new string[] { UserName, UserPassword };
            }

            return null;
        }
    }
}
