using System;

namespace chatapp_server
{
    public class LoginRequest : IRequest
    {
        public string UserName { get; private set; }
        public string UserPassword { get; private set; }

        private string passwordseparator = ((char)(1)).ToString();

        public LoginRequest(string data)
        {
            if (!IsValid(data))
            {
                throw new ArgumentException();
            }

            UserName = GetUserName(data);
            UserPassword = GetPassword(data);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        private bool IsValid(string data)
        {
            if (data.Contains(passwordseparator))
            {
                if (!data.StartsWith(passwordseparator) && !data.EndsWith(passwordseparator))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets user name, assuming, that name begins at the beginning of the body and ends at password separator.
        /// </summary>
        /// <param name="data">request body</param>
        /// <returns></returns>
        private string GetUserName(string data)
        {
            string username = data.Substring(0, data.IndexOf(passwordseparator));
            return username;
        }

        /// <summary>
        /// Gets user password, assuming, that password begins behind the password separator, and ends at the data end.
        /// </summary>
        /// <param name="data">request body</param>
        /// <returns></returns>
        private string GetPassword(string data)
        {
            string password = data.Substring(data.IndexOf(passwordseparator) + 1, data.Length - (data.IndexOf(passwordseparator) + 1));
            return password;
        }

        
    }
}
