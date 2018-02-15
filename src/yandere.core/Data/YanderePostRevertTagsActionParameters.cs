using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YanderePostRevertTagsActionParameters : YandereActionParameters
    {
        public const string ParamName_PostID = "id";
        public const string ParamName_TagHistoryID = "history_id";

        public uint ID
        {
            get => (uint)this[ParamName_PostID];
            set => this[ParamName_PostID] = value;
        }

        public uint TagHistroyID
        {
            get => (uint)this[ParamName_TagHistoryID];
            set => this[ParamName_TagHistoryID] = value;
        }

        public YanderePostRevertTagsActionParameters(uint postID, uint tagHistoryID) : base(2)
        {
            this.AddParameter(ParamName_PostID, postID);
            this.AddParameter(ParamName_TagHistoryID, tagHistoryID);
        }
    }
}
