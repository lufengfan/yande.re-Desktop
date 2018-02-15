using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YanderePostCreateActionParameters : YandereActionParameters
    {
        public const string ParamName_Tags = "post[tags]";
        public const string ParamName_File = "post[file]";
        public const string ParamName_Rating = "post[rating]";
        public const string ParamName_Source = "post[source]";
        public const string ParamName_IsRatingLocked = "post[is_rating_locked]";
        public const string ParamName_IsNoteLocked = "post[is_note_locked]";
        public const string ParamName_ParentID = "post[parent_id]";
        public const string ParamName_MD5 = "md5";

        public YandereTagCollection Tags
        {
            get => (YandereTagCollection)this[ParamName_Tags];
            set => this[ParamName_Tags] = value;
        }

        [Obsolete("未实现。", true)]
        public Uri File { get; set; }

        public YanderePostRating Rating
        {
            get => (YanderePostRating)Enum.Parse(typeof(YanderePostRating), (string)this[ParamName_Rating], true);
            set
            {
                if (!Enum.IsDefined(typeof(YanderePostRating), value))
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"未在 {typeof(YanderePostRating)} 枚举中定义。");

                this[ParamName_Rating] = Enum.GetName(typeof(YanderePostRating), value).ToLower();
            }
        }

        public Uri Source
        {
            get => (Uri)this[ParamName_Source];
            set => this[ParamName_Source] = value;
        }

        public bool IsRatingLocked
        {
            get => (bool)this[ParamName_IsRatingLocked];
            set => this[ParamName_IsRatingLocked] = value;
        }

        public bool IsNoteLocked
        {
            get => (bool)this[ParamName_IsNoteLocked];
            set => this[ParamName_IsNoteLocked] = value;
        }

        public uint? ParentID
        {
            get => (uint?)this[ParamName_ParentID];
            set => this[ParamName_ParentID] = value;
        }

        public string MD5
        {
            get => (string)this[ParamName_MD5];
            set => this[ParamName_MD5] = value;
        }

        public YanderePostCreateActionParameters() : base(8)
        {
            this.AddParameter(ParamName_Tags, null);
            this.DefaultParameters.Add(ParamName_File, null);
            this.DefaultParameters.Add(ParamName_Rating, Enum.GetName(typeof(YanderePostRating), YanderePostRating.Questionable).ToLower());
            this.DefaultParameters.Add(ParamName_Source, null);
            this.DefaultParameters.Add(ParamName_IsRatingLocked, false);
            this.DefaultParameters.Add(ParamName_IsNoteLocked, false);
            this.DefaultParameters.Add(ParamName_ParentID, null);
            this.DefaultParameters.Add(ParamName_MD5, null);
        }
    }
}
