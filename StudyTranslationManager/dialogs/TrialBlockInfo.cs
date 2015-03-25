using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyTranslationManager.entities;

namespace StudyTranslationManager.dialogs
{
    public partial class TrialBlockInfo : Form
    {
        public TrialBlockInfo(TrialBlock block)
        {
            InitializeComponent();

            Cursor = Cursors.WaitCursor;

            IQueryable<Trial> trials = from trial in Trial.GetAllTrials().AsQueryable()
                                 where trial.BlockId == block.Id
                                 select trial;
            int numTrialsCorrected = 0;
            int numTrialsTranslated = 0;
            int numTrials = (block.ToId - block.FromId + 1);
            foreach(Trial t in trials)
            {
                if (t.Corrected.Completed)
                    numTrialsCorrected++;

                if (t.Translated.Completed)
                    numTrialsTranslated++;
            }
            float progress = ((numTrialsCorrected+numTrialsTranslated)/(numTrials*2f));
            

            StringBuilder details = new StringBuilder();
            details.AppendFormat("Block ID: {0}\r\n", block.Id);
            details.AppendFormat("Trial Count: {0}\r\n", numTrials);
            details.AppendFormat("Translator: {0}\r\nProofreader: {1}\r\n", block.Translator.Name, block.Proofreader.Name);
            details.AppendLine();
            details.AppendFormat("Trials seen: {0}/{1}\r\n", trials.Count(), trials.Count());
            details.AppendFormat("Trials translated: {0}/{1}\r\n", numTrialsTranslated, numTrials);
            details.AppendFormat("Trials corrected: {0}/{1}\r\n", numTrialsCorrected, numTrials);
            details.AppendLine();
            details.AppendFormat("Progress: {0:P0}", progress);
            Cursor = Cursors.Default;

            textBox1.Text = details.ToString();
            groupBox1.Text = "Block #" + block.Id;
        }
    }
}
