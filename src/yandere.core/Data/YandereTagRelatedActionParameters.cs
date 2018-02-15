using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereTagRelatedActionParameters : YandereActionParameters
    {
        public const string ParamName_Tags = "tags";
        public const string ParamName_Type = "type";

        public StringCollection Tags
        {
            get => (StringCollection)this[ParamName_Tags];
            set => this[ParamName_Tags] = value ?? throw new ArgumentNullException(nameof(value));
        }

        public YandereTagType Type
        {
            get => (YandereTagType)Enum.ToObject(typeof(YandereTagType), (int)this[ParamName_Type]);
            set
            {
                if (!Enum.IsDefined(typeof(YandereTagType), value))
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"未在 {typeof(YandereTagType)} 枚举中定义。");

                this[ParamName_Type] = (int)value;
            }
        }

        public YandereTagRelatedActionParameters(StringCollection tags) : base(2)
        {
            if (tags == null) throw new ArgumentNullException(nameof(tags));

            this.AddParameter(ParamName_Tags, tags);
            this.DefaultParameters.Add(ParamName_Type, (int)YandereTagType.Any);
        }

        public YandereTagRelatedActionParameters(StringCollection tags, YandereTagType type) : this(tags)
        {
            this.AddParameter(ParamName_Type, type);
        }
    }
}
