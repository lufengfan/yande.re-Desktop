using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereTagUpdateActionParameters : YandereActionParameters
    {
        public const string ParamName_Name = "name";
        public const string ParamName_Type = "tag[tag_type]";
        public const string ParamName_IsAmbiguous = "tag[is_ambiguous]";

        public string Name
        {
            get => (string)this[ParamName_Name];
            set => this[ParamName_Name] = value ?? throw new ArgumentNullException(nameof(value));
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

        public bool IsAmbiguous
        {
            get => Convert.ToBoolean((int)this[ParamName_IsAmbiguous]);
            set => Convert.ToInt32(value);
        }

        public YandereTagUpdateActionParameters(string name) : base(3)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.AddParameter(ParamName_Name, name);
            this.DefaultParameters.Add(ParamName_Type, (int)YandereTagType.Any);
            this.DefaultParameters.Add(ParamName_IsAmbiguous, Convert.ToInt32(false));
        }
    }
}
