namespace AktieHandelApi
{
    public enum Role
    {
        user, admin, superuser
    }
    public interface IAuthenticator
    {
        Role? Authenticate(string username, string password);
    }
}
