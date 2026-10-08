using System.Data;

namespace AktieHandelApi
{
    public class SimpleAuthenticator : IAuthenticator
    {
        public Role? Authenticate(string username, string password)
        {
            if (username == "admin" && password == "Password1234")
            {
                return Role.admin;
            }
            else if (username == "user" && password == "1234")
            {
                return Role.user;
            }

            return null;
        }
    }
}
