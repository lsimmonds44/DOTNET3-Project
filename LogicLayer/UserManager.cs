using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataObjects;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        internal string HashSHA256(string source)
        {
            var result = "";
            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            var s = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString();
            return result;
        }

        public bool UpdatePassword(int userID, string oldPassword, string newPassword)
        {
            var result = false;
            try
            {
                if (1 == UserAccessor.UpdatePasswordHash(userID,
                    HashSHA256(oldPassword), HashSHA256(newPassword)))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public User AuthenticateUser(string username, string password)
        {
            User user = null;

            if (username.Length < 5 || username.Length > 20)
            {
                throw new ApplicationException("Invalid Username");
            }
            if (password.Length < 7) 
            {                        
                throw new ApplicationException("Invalid Password");
            }

            try
            {
                //if (1 == UserAccessor.VerifyUsernameAndPassword(username, HashSHA256(password)))
                //{
                    password = null;
                    user = UserAccessor.RetrieveUserByUsername(username);
                    //var roles = UserAccessor.RetrieveUserRoles(user.UserID);
                    //user.Roles = roles;
                //}
                //else
                //{
                //    throw new ApplicationException("Authentication Failed!");
                //}

            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
    }
}

