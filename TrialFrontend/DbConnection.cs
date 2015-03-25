using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialFrontend.entities;
using System.Data.SQLite;
using System.Data.Linq.Mapping;

namespace TrialFrontend
{
    public class DbConnection : DataContext
    {
        public Table<User> Users;
        public Table<TrialBlock> TrialBlocks;
        public Table<Trial> Trials;

        public DbConnection(string c) : base(c) { }
        public DbConnection(SQLiteConnection c) : base(c) { }
        //public DbConnection(SQLiteConnection c, MappingSource ms) : base(c, ms) { }

        public static DbConnection FromFilePath(string fp)
        {
            SQLiteConnection sq = new SQLiteConnection("Data Source=" + fp + ";Version=3");
            return new DbConnection(sq);
        }

        public static SQLiteConnection SQLiteFromFilePath(string fp)
        {
            SQLiteConnection sq = new SQLiteConnection("Data Source=" + fp + ";Version=3");
            return sq.OpenAndReturn();
        }
    }
}
