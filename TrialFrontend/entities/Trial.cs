using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Linq.Provider;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Data.SQLite;

namespace TrialFrontend.entities
{
    [Table(Name = "trials")]
    public class Trial
    {
        [Column(Name = "id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "blockId")]
        public int BlockId;

        private EntityRef<TrialBlock> _TrialBlock;
        [Association(Storage = "_TrialBlock", ThisKey = "BlockId")]
        public TrialBlock Block
        {
            get { return this._TrialBlock.Entity; }
            set { this._TrialBlock.Entity = value; this.BlockId = value.Id; }
        }

        [Column(Name = "translated")]
        public string _Translated { get; set; }

        [Column(Name = "corrected")]
        public string _Corrected { get; set; }

        [Column(Name = "filepath")]
        public string Filepath { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        public Milestone Translated {
            get
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Milestone));
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(this._Translated);
                sw.Flush();
                stream.Position = 0;

                return (Milestone)ser.ReadObject(stream);
            }
            set
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Milestone));

                ser.WriteObject(stream, value);

                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);

                this._Translated = sr.ReadToEnd();
            }
        }

        public Milestone Corrected
        {
            get
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Milestone));
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(this._Corrected);
                sw.Flush();
                stream.Position = 0;

                return (Milestone)ser.ReadObject(stream);
            }
            set
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Milestone));

                ser.WriteObject(stream, value);

                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);

                this._Corrected = sr.ReadToEnd();
            }
        }

        public bool IsNew;

        public Trial() { }

        public Trial(int id)
        {
            SQLiteCommand q = new SQLiteCommand("SELECT * FROM trials WHERE id = " + id, Program.SqliteConnection);
            using (SQLiteDataReader d = q.ExecuteReader())
            {
                if (d.Read())
                {
                    this.Id = id;
                    this.IsNew = false;

                    for (int col = 0; col < d.FieldCount; col++)
                    {
                        if (d.GetName(col) == "blockId")
                        {
                            this.Block = new TrialBlock(d.GetInt32(col));
                            this.BlockId = this.Block.Id;
                        }
                        else if (d.GetName(col) == "translated")
                        {
                            this._Translated = d.GetString(col);
                        }
                        else if (d.GetName(col) == "corrected")
                        {
                            this._Corrected = d.GetString(col);
                        }
                        else if (d.GetName(col) == "filepath")
                        {
                            if(!d.IsDBNull(col))
                            {
                                this.Filepath = d.GetString(col);
                            }
                            else
                            {
                                this.Filepath = "";
                            }
                                
                        }
                        else if (d.GetName(col) == "notes")
                        {
                            if (!d.IsDBNull(col))
                            {
                                this.Notes = d.GetString(col);
                            }
                            else
                            {
                                this.Notes = "";
                            }
                            
                        }
                    }
                }
                else
                {
                    this.IsNew = true;
                    this.Corrected = new Milestone();
                    this.Translated = new Milestone();
                    this.Filepath = "";
                    this.Notes = "";
                }
            }
        }

        public void UpdateToDb()
        {
            var idParam = new SQLiteParameter("@id", System.Data.DbType.Int32) { Value = this.Id };
            var blockIdParam = new SQLiteParameter("@blockId", System.Data.DbType.Int32) { Value = this.BlockId };
            var correctedParam = new SQLiteParameter("@corrected", System.Data.DbType.String) { Value = this._Corrected };
            var translatedParam = new SQLiteParameter("@translated", System.Data.DbType.String) { Value = this._Translated };
            var filepathParam = new SQLiteParameter("@filepath", System.Data.DbType.String) { Value = this.Filepath };
            var notesParam = new SQLiteParameter("@notes", System.Data.DbType.String) { Value = this.Notes };

            if (this.IsNew)
            {
                SQLiteCommand c = new SQLiteCommand(@"INSERT INTO trials 
                                                    (id, blockId, corrected, translated, filepath, notes)
                                             VALUES (@id, @blockId, @corrected, @translated, @filepath, @notes)", Program.SqliteConnection);
                
                c.Parameters.Add(idParam);
                c.Parameters.Add(blockIdParam);
                c.Parameters.Add(correctedParam);
                c.Parameters.Add(translatedParam);
                c.Parameters.Add(filepathParam);
                c.Parameters.Add(notesParam);

                c.ExecuteNonQuery();

                this.IsNew = false;
            }
            else
            {
                SQLiteCommand c = new SQLiteCommand(@"UPDATE trials 
                                                    SET blockId = @blockId,
                                                        corrected = @corrected, 
                                                        translated = @translated, 
                                                        filepath = @filepath, 
                                                        notes = @notes
                                                    WHERE id = @id", Program.SqliteConnection);
                c.Parameters.Add(idParam);
                c.Parameters.Add(blockIdParam);
                c.Parameters.Add(correctedParam);
                c.Parameters.Add(translatedParam);
                c.Parameters.Add(filepathParam);
                c.Parameters.Add(notesParam);

                c.ExecuteNonQuery();
            }
        }
    }
}
