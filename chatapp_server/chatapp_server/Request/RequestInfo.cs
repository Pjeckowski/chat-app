using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatapp_server
{
    public class RequestInfo
    {
        public string RequestStart { get; private set; }
        public string RequestEnd { get; private set; }
        public string Command { get; private set; }
        public string PMessage { get; private set; }
        public string RMessage { get; private set; }
        public string PasswordSeparator { get; private set; }

        #region ctor

        public RequestInfo()
        {
            RequestStart = ((char)(24)).ToString();
            RequestEnd = ((char)(25)).ToString();
            Command = (char)(26) + "comm/";
            PMessage = (char)(26) + "pmes";
            RMessage = (char)(26) + "rmes";
            PasswordSeparator = "||";
        }

        public RequestInfo(string RequestStart, string RequestEnd, string Command, string PMessage, string RMessage, string PasswordSeparator)
        {
            this.RequestStart = RequestStart;
            this.RequestEnd = RequestEnd;
            this.Command = Command;
            this.PMessage = PMessage;
            this.RMessage = RMessage;
            this.PasswordSeparator = PasswordSeparator;
        }

        #endregion

        #region functions for request's factory

        public bool IsRequest(string RequestBody)
        {
            if (RequestBody.IndexOf(RequestStart) == 0)
            {
                if (RequestBody.IndexOf(RequestEnd) == (RequestBody.Length - RequestEnd.Length))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// If request contains any command, returns the command body. Else null.
        /// </summary>
        /// <param name="RequestBody"></param>
        /// <returns></returns>
        public string IsCommand(string RequestBody)
        {
            if (IsRequest(RequestBody) && RequestBody.IndexOf(Command) == RequestStart.Length)
            {
                int startindex = RequestBody.IndexOf(Command) + Command.Length;
                int commandlength = RequestBody.Length - RequestStart.Length - RequestEnd.Length;
                
                return RequestBody.Substring(startindex, commandlength);
            }
            return null;
        }

        /// <summary>
        /// If RequestBody contains private message returns the message contents. Else null.
        /// </summary>
        /// <param name="RequestBody"></param>
        /// <returns></returns>
        public string IsPMessage(string RequestBody)
        {
            if (IsRequest(RequestBody) && RequestBody.IndexOf(PMessage) == RequestStart.Length)
            {
                int startindex = RequestBody.IndexOf(PMessage) + PMessage.Length;
                int messagelength = RequestBody.Length - RequestStart.Length - RequestEnd.Length;

                return RequestBody.Substring(startindex, messagelength);
            }
            return null;
        }

        /// <summary>
        /// /// If RequestBody contains room message returns the message contents. Else null.
        /// </summary>
        /// <param name="RequestBody"></param>
        /// <returns>message contents or null</returns>
        public string IsRMessage(string RequestBody)
        {
            if (IsRequest(RequestBody) && RequestBody.IndexOf(RMessage) == RequestStart.Length)
            {
                int startindex = RequestBody.IndexOf(RMessage) + RMessage.Length;
                int messagelength = RequestBody.Length - RequestStart.Length - RequestEnd.Length;

                return RequestBody.Substring(startindex, messagelength);
            }
            return null;
        }

        #endregion
    }
}
