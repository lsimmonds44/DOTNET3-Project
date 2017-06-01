using DataObjects;

namespace LogicLayer
{
    public interface IUserManager
    {
        User AuthenticateUser(string username, string password);
        bool UpdatePassword(int userID, string oldPassword, string newPassword);
    }
}