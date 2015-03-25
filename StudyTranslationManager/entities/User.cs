using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SQLite;

namespace StudyTranslationManager.entities
{
    [Table(Name = "users")]
    public class User
    {
        [Column(Name = "username", IsPrimaryKey = true)]
        public string Username { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "roles")]
        private string _Roles;
        public string[] Roles
        {
            get
            {
                return _Roles.Split(',');
            }
            set
            {
                this._Roles = String.Join(",", value);
            }
        }

        [Column(Name = "password")]
        public string Password { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public User() { }

        public bool IsNew = true;

        /// <summary>
        /// New User from DB
        /// </summary>
        /// <param name="uid">Username</param>
        public User(string uid)
        {
            SQLiteCommand q = new SQLiteCommand("SELECT * FROM users WHERE username = '" + uid + "'", Program.SqliteConnection);
            using (SQLiteDataReader d = q.ExecuteReader())
            {
                if (d.Read())
                {
                    this.Username = (string)d["username"];
                    this.Name = (string)d["name"];
                    this.Password = (string)d["password"];
                    this._Roles = (string)d["roles"];
                }
            }

            IsNew = false;

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

        /// <summary>
        /// Delete this user from the DB
        /// </summary>
        public void Delete()
        {
            if(this.Username.Length > 0)
            {
                SQLiteCommand q = new SQLiteCommand("DELETE FROM users WHERE username='"+Username.Replace("'", "''")+"'", Program.SqliteConnection);
                q.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Sync changes in object to DB or create new one
        /// </summary>
        public void UpdateToDb()
        {
            var usernameParam = new SQLiteParameter("@username", System.Data.DbType.String) { Value = this.Username };
            var nameParam = new SQLiteParameter("@name", System.Data.DbType.String) { Value = this.Name };
            var passwordParam = new SQLiteParameter("@password", System.Data.DbType.String) { Value = this.Password };
            var rolesParam = new SQLiteParameter("@roles", System.Data.DbType.String) { Value = this._Roles };
            
            if (this.IsNew)
            {
                SQLiteCommand c = new SQLiteCommand(@"INSERT INTO users 
                                                    (username, name, password, roles)
                                             VALUES (@username, @name, @password, @roles)", Program.SqliteConnection);

                c.Parameters.Add(usernameParam);
                c.Parameters.Add(nameParam);
                c.Parameters.Add(passwordParam);
                c.Parameters.Add(rolesParam);

                c.ExecuteNonQuery();

                this.IsNew = false;
            }
            else
            {
                SQLiteCommand c = new SQLiteCommand(@"UPDATE users 
                                                    SET name = @name, 
                                                        password = @password, 
                                                        roles = @roles
                                                    WHERE username = @username", Program.SqliteConnection);
                c.Parameters.Add(usernameParam);
                c.Parameters.Add(nameParam);
                c.Parameters.Add(passwordParam);
                c.Parameters.Add(rolesParam);

                c.ExecuteNonQuery();
            }
        }
    }
}
