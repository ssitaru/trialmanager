using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialFrontend.entities;
using System.Security.Cryptography;

namespace TrialFrontend
{
    class Utils
    {
        public static User GetUserByUsername(string username)
        {
            var selectedUser = from user in User.GetAllUsers().AsQueryable()
                               where user.Username == username
                               select user;

            foreach(User u in selectedUser)
            {
                return u;
            }

            return null;
        }
        public static string Base64Encode(byte[] bytes)
        {
            return System.Convert.ToBase64String(bytes);
        }

        public static string GetSHA1Hash(string plaintext)
        {
            SHA1Managed sha1 = new SHA1Managed();

            byte[] b = System.Text.Encoding.UTF8.GetBytes(plaintext);
            byte[] digest = sha1.ComputeHash(b);

            return Base64Encode(digest);
        }

        public static bool CheckSHA1Hash(string plaintext, string hash)
        {
            string plaintextHash = GetSHA1Hash(plaintext);
            if (plaintextHash == hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
