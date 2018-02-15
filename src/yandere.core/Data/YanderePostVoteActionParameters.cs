using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YanderePostVoteActionParameters : YandereActionParameters
    {
        public const string ParamName_PostID = "id";
        public const string ParamName_Score = "score";

        public uint PostID
        {
            get => (uint)this[ParamName_PostID];
            set => this[ParamName_PostID] = value;
        }

        public YanderePostVoteScore Score
        {
            get => (YanderePostVoteScore)Enum.ToObject(typeof(YanderePostVoteScore), (int)this[ParamName_Score]);
            set => this[ParamName_Score] = (int)value;
        }

        public YanderePostVoteActionParameters(uint postID, YanderePostVoteScore score) : base(2)
        {
            this.AddParameter(ParamName_PostID, postID);
            this.AddParameter(ParamName_Score, score);
        }
    }
}
