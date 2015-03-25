using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;

namespace TrialFrontend.entities
{
    [Table(Name="users")]
    public class User
    {
        [Column(Name = "username",  IsPrimaryKey = true)]
        public string Username { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "roles")]
        private string _roles;
        public string[] Roles { 
            get
            {
                return _roles.Split(',');
            } 
            set
            {
                this._roles = String.Join(",", value);
            } 
        }

        [Column(Name = "password")]
        public string Password { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public User() { }

        public User(string uid) 
        {
            SQLiteCommand q = new SQLiteCommand("SELECT * FROM users WHERE username = \""+uid+"\"", Program.SqliteConnection);
            using (SQLiteDataReader d = q.ExecuteReader())
            {
                if (d.Read())
                {
                    this.Username = (string)d["username"];
                    this.Name = (string)d["name"];
                    this.Password = (string)d["password"];
                    this._roles = (string)d["roles"];
                }
            }

            
        }

        public static List<User> GetAllUsers()
        {
            List<User> ret = new List<User>();
            SQLiteCommand q = new SQLiteCommand("SELECT username FROM users", Program.SqliteConnection);
            SQLiteDataReader d = q.ExecuteReader();
            while (d.Read())
            {
                ret.Add(new User((string)d["username"]));
            }

            return ret;
        }
    }
}
