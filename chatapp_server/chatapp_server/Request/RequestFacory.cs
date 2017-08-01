using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public class RequestFacory
    {
        public string KickRequestCommand { get; private set; }
        public string LoginRequestCommand { get; private set; }

        public RequestFacory()
        {
            KickRequestCommand = "kick ";
            LoginRequestCommand = "login ";
        }

        public IRequest GetRequest(User CallingUser, string RequestBody, RequestInfo RequestInfo)
        {
            string CommandBody;
            
            if (null != (CommandBody = RequestInfo.IsCommand(RequestBody)))
            {

                if (IsKickRequest(CommandBody))
                {
                    return new KickRequest(CallingUser, KRGetUserName(CommandBody));
                }
                else
                    if (IsLoginRequest(CommandBody))
                    {
                        string[] NamePassword = LRGetUserInfo(CommandBody, RequestInfo);
                        return new LoginRequest(NamePassword[0], NamePassword[1]);
                    }
            }
            else
            {
                string Message;
                if(null != (Message = RequestInfo.IsRMessage(RequestBody)))
                {
                }
            }
            return null;
        }

        private bool IsKickRequest(string CommandBody)
        {
            if (0 == CommandBody.IndexOf(KickRequestCommand))
            {
                return true;
            }
            return false;
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
