using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyTranslationManager.entities;
using System.Data.SQLite;
using System.Data.Linq.Mapping;
using System.IO;


namespace StudyTranslationManager
{
    public class DbConnection
    {
        public static string UsersTableCreateString = @"CREATE TABLE users (
	                                                        `username`	TEXT NOT NULL,
	                                                        `name`	TEXT,
	                                                        `password`	TEXT NOT NULL,
	                                                        `roles`	TEXT NOT NULL,
	                                                        PRIMARY KEY(username));";

        public static string TrialsTableCreateString = @"CREATE TABLE trials (
	                                                        `id`	INTEGER NOT NULL,
	                                                        `blockId`	INTEGER,
	                                                        `translated`	TEXT,
	                                                        `corrected`	TEXT,
	                                                        `filepath`	TEXT,
	                                                        `notes`	TEXT,
	                                                        PRIMARY KEY(id),
	                                                        FOREIGN KEY(`blockId`) REFERENCES trialblocks ( id ));";

        public static string TrialBlocksTableCreateString = @"CREATE TABLE trialblocks (
	                                                        `id`	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                                        `assignTimestamp`	TEXT,
	                                                        `fromId`	INTEGER NOT NULL,
	                                                        `toId`	INTEGER NOT NULL,
	                                                        `translator`	TEXT,
	                                                        `proofreader`	TEXT,
	                                                        `done`	INTEGER,
	                                                        `notes`	TEXT,
	                                                        FOREIGN KEY(`translator`) REFERENCES users ( username ),
	                                                        FOREIGN KEY(`proofreader`) REFERENCES users ( username ));";

        public static SQLiteConnection SQLiteFromFilePath(string fp)
        {
            SQLiteConnection sq;

            if(File.Exists(fp))
            {
                sq = new SQLiteConnection("Data Source=" + fp + ";Version=3");
                sq.Open();
            }
            else
            {
                SQLiteConnection.CreateFile(fp);
                sq = new SQLiteConnection("Data Source=" + fp + ";Version=3");
                sq.Open();

                SQLiteCommand c = new SQLiteCommand(UsersTableCreateString, sq);
                c.ExecuteNonQuery();

                c = new SQLiteCommand(TrialsTableCreateString, sq);
                c.ExecuteNonQuery();

                c = new SQLiteCommand(TrialBlocksTableCreateString, sq);
                c.ExecuteNonQuery();

            }
            
            return sq;
        }

        
    }
}
