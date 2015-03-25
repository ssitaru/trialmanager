using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using StudyTranslationManager.entities;

namespace StudyTranslationManager
{
    public static partial class Utils
    {

        public static string Base64Encode(byte[] bytes)
        {
            return System.Convert.ToBase64String(bytes);
        }

        public static byte[] Base64Decode(string s)
        {
            return System.Convert.FromBase64String(s);
        }

        public static string GetSHA1Hash(string plaintext)
        {
            SHA1Managed sha1 = new SHA1Managed();

            byte[] b = System.Text.Encoding.UTF8.GetBytes(plaintext);
            byte[] digest = sha1.ComputeHash(b);

            return Base64Encode(digest);
        }

        public static User GetUserByUsername(string username)
        {
            var selectedUser = from user in User.GetAllUsers().AsQueryable()
                               where user.Username == username
                               select user;

            return selectedUser.First();
        }

    }
}
