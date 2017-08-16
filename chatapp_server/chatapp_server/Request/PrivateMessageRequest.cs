using System;

namespace chatapp_server
{
    public class PrivateMessageRequest : IRequest
    {
        public IUser CallingUser { get; private set; }
        public string TargetUserName { get; private set; }
        public string Message { get; private set; }

        private string messageseparator = ((char)1).ToString();


        public PrivateMessageRequest(IUser User, string data)
        {
            if(!IsValid(data))
            {
                throw new ArgumentException();
            }
            this.CallingUser = CallingUser;
            this.TargetUserName = GetUserName(data);
            this.Message = GetMessage(data);
        }

        /// <summary>
        /// Gets user name, assuming, that name begins at the beginning of the body and ends at message separator.
        /// </summary>
        /// <param name="data">request body</param>
        /// <returns></returns>
        private string GetUserName(string data)
        {
            string username = data.Substring(0, data.IndexOf(messageseparator));
            return username;
        }

        /// <summary>
        /// Gets message, assuming, that it begins behind the message separator, and ends at the data end.
        /// </summary>
        /// <param name="data">request body</param>
        /// <returns></returns>
        private string GetMessage(string data)
        {
            string message = data.Substring(data.IndexOf(messageseparator) + 1, data.Length - (data.IndexOf(messageseparator) + 1));
            return message;
        }

        private bool IsValid(string data)
        {
            if(string.Empty != data && null != data)
            {
                if(data.Contains(messageseparator) && !data.StartsWith(messageseparator) 
                   && !data.EndsWith(messageseparator))
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
