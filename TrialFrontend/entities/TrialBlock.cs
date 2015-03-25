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

namespace TrialFrontend.entities
{
    [Table(Name="trialblocks")]
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
                q = new SQLiteCommand("SELECT id FROM trialblocks WHERE translator = \""+uid+"\" OR proofreader = \""+uid+"\"", Program.SqliteConnection);
            }
            SQLiteDataReader d = q.ExecuteReader();
            while(d.Read())
            {
                ret.Add(d.GetInt32(0));
            }

            return ret;
        }

        public TrialBlock() { }

        public TrialBlock(int blockId)
        {
            SQLiteCommand q = new SQLiteCommand("SELECT * FROM trialblocks WHERE id = "+blockId.ToString(), Program.SqliteConnection);
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

        public static List<TrialBlock> GetAllTrialBlocks()
        {
            List<TrialBlock> ret = new List<TrialBlock>();
            foreach (int id in GetAllTrialBlocksForUid())
            {
                ret.Add(new TrialBlock(id));
            }

            return ret;
        }

        public override string ToString()
        {
            return "#" + Id.ToString() + " (" + FromId.ToString() + "-" + ToId.ToString() + ")";
        }
    }
}
