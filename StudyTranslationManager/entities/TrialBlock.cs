using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq.Provider;
using System.Globalization;
using System.Data.SQLite;

namespace StudyTranslationManager.entities
{
    [Table(Name = "trialblocks")]
    public class TrialBlock
    {
        [Column(Name = "id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "fromId")]
        public int FromId { get; set; }

        [Column(Name = "toId")]
        public int ToId { get; set; }

        [Column(Name = "translator")]
        public string TranslatorId;

        private EntityRef<User> _Translator;
        [Association(Storage = "_Translator", ThisKey = "TranslatorId")]
        public User Translator
        {
            get { return this._Translator.Entity; }
            set { this._Translator.Entity = value; this.TranslatorId = value.Username; }
        }

        [Column(Name = "proofreader")]
        public string ProofreaderId;

        private EntityRef<User> _Proofreader;
        [Association(Storage = "_Proofreader", ThisKey = "ProofreaderId")]
        public User Proofreader
        {
            get { return this._Proofreader.Entity; }
            set { this._Proofreader.Entity = value; this.ProofreaderId = value.Username; }
        }

        [Column(Name = "done")]
        public int Done { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "assignTimestamp")]
        public string _Timestamp { get; set; }

        public DateTime Timestamp
        {
            get
            {
                return DateTime.Parse(this._Timestamp, CultureInfo.CurrentUICulture, DateTimeStyles.RoundtripKind);
            }
            set
            {
                this._Timestamp = value.ToString("o");
            }
        }

        public static List<int> GetAllTrialBlocksForUid(string uid = "")
        {
            List<int> ret = new List<int>();
            SQLiteCommand q = new SQLiteCommand("SELECT id FROM trialblocks", Program.SqliteConnection);
            if (uid != "")
            {
                q = new SQLiteCommand("SELECT id FROM trialblocks WHERE translator = \"" + uid + "\" OR proofreader = \"" + uid + "\"", Program.SqliteConnection);
            }
            SQLiteDataReader d = q.ExecuteReader();
            while (d.Read())
            {
                ret.Add(d.GetInt32(0));
            }

            return ret;
        }

        public static List<TrialBlock> GetAllTrialBlocks()
        {
            List<TrialBlock> ret = new List<TrialBlock>();
            foreach (int id in GetAllTrialBlocksForUid())
            {
                ret.Add(new TrialBlock(id));
            }

            return ret;
        }

        public TrialBlock() { }

        public TrialBlock(int blockId)
        {
            SQLiteCommand q = new SQLiteCommand("SELECT * FROM trialblocks WHERE id = " + blockId.ToString(), Program.SqliteConnection);
            using (SQLiteDataReader d = q.ExecuteReader())
            {
                while (d.Read())
                {
                    for (int col = 0; col < d.FieldCount; col++)
                    {
                        if (d.GetName(col) == "id")
                        {
                            this.Id = d.GetInt32(col);
                        }
                        else if (d.GetName(col) == "fromId")
                        {
                            this.FromId = d.GetInt32(col);
                        }
                        else if (d.GetName(col) == "toId")
                        {
                            this.ToId = d.GetInt32(col);
                        }
                        else if (d.GetName(col) == "assignTimestamp")
                        {
                            this._Timestamp = d.GetString(col);
                        }
                        else if (d.GetName(col) == "translator")
                        {
                            this.Translator = new User(d.GetString(col));
                        }
                        else if (d.GetName(col) == "proofreader")
                        {
                            this.Proofreader = new User(d.GetString(col));
                        }
                        else if (d.GetName(col) == "done")
                        {
                            this.Done = d.GetInt32(col);
                        }
                        else if (!d.IsDBNull(col) && d.GetName(col) == "notes")
                        {
                            this.Notes = d.GetString(col);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Delete this trialblock from the DB
        /// </summary>
        public void Delete()
        {
            if (this.Id != 0)
            {
                SQLiteCommand q = new SQLiteCommand("DELETE FROM trialblocks WHERE id='" + Id + "'", Program.SqliteConnection);
                q.ExecuteNonQuery();
            }
        }

        public void UpdateToDb()
        {
            var idParam = new SQLiteParameter("@id", System.Data.DbType.Int32) { Value = this.Id };
            var fromIdParam = new SQLiteParameter("@fromId", System.Data.DbType.Int32) { Value = this.FromId };
            var toIdParam = new SQLiteParameter("@toId", System.Data.DbType.Int32) { Value = this.ToId };
            var timestampParam = new SQLiteParameter("@timestamp", System.Data.DbType.String) { Value = this._Timestamp };
            var proofreaderParam = new SQLiteParameter("@proofreader", System.Data.DbType.String) { Value = this.Proofreader.Username };
            var translatorParam = new SQLiteParameter("@translator", System.Data.DbType.String) { Value = this.Translator.Username };
            var doneParam = new SQLiteParameter("@done", System.Data.DbType.Int32) { Value = this.Done };
            var notesParam = new SQLiteParameter("@notes", System.Data.DbType.String) { Value = this.Notes };

            if (this.Id == 0)
            {
                SQLiteCommand c = new SQLiteCommand(@"INSERT INTO trialblocks 
                                                    (fromId, toId, assignTimestamp, proofreader, translator, done, notes)
                                             VALUES (@fromId, @toId, @timestamp, @proofreader, @translator, @done, @notes)", Program.SqliteConnection);

                c.Parameters.Add(fromIdParam);
                c.Parameters.Add(toIdParam);
                c.Parameters.Add(timestampParam);
                c.Parameters.Add(translatorParam);
                c.Parameters.Add(proofreaderParam);
                c.Parameters.Add(doneParam);
                c.Parameters.Add(notesParam);

                c.ExecuteNonQuery();
            }
            else
            {
                SQLiteCommand c = new SQLiteCommand(@"UPDATE trialblocks 
                                                    SET fromId = @fromId,
                                                        toId = @toId, 
                                                        assignTimestamp = @timestamp, 
                                                        proofreader = @proofreader, 
                                                        translator = @translator,
                                                        done = @done,
                                                        notes = @notes
                                                    WHERE id = @id", Program.SqliteConnection);
                c.Parameters.Add(idParam);
                c.Parameters.Add(fromIdParam);
                c.Parameters.Add(toIdParam);
                c.Parameters.Add(timestampParam);
                c.Parameters.Add(translatorParam);
                c.Parameters.Add(proofreaderParam);
                c.Parameters.Add(doneParam);
                c.Parameters.Add(notesParam);

                c.ExecuteNonQuery();
            }
        }
    }
}
