using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace StudyTranslationManager.entities
{
    [DataContract]
    public class Milestone
    {
        public Milestone(MilestoneType mt)
        {
            Type = mt;
        }

        public Milestone(MilestoneType mt, bool c, DateTime d)
        {
            Type = mt;
            Completed = c;
            Timestamp = d;
        }

        public Milestone(){ }

        [DataMember]
        public MilestoneType Type;

        [DataMember]
        public bool Completed = false;

        [DataMember]
        public DateTime Timestamp = DateTime.Now;
    }

    public enum MilestoneType
    {
        TRANSLATION,
        CORRECTION,
        REGISTRATION
    }
}


