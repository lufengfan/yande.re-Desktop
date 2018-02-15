using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YandereTagsListActionParameters : YandereActionParameters
    {
        public const string ParamName_Limit = "limit";
        public const string ParamName_Page = "page";
        public const string ParamName_Order = "order";
        public const string ParamName_ID = "id";
        public const string ParamName_AfterID = "after_id";
        public const string ParamName_Name = "name";
        public const string ParamName_NamePattern = "name_pattern";
        
        public const int DefaultLimit = 40;
        //public const int MaxLimit = 100;
        public const string DefaultNamePattern = "*";

        /// <summary>
        /// 获取或设置一个值，指示检索的 <see cref="YandereTag"/> 的数量。
        /// </summary>
        /// <remarks>
        /// 当值设为 0 时，将返回所有的 <see cref="YandereTag"/> 。
        /// </remarks>
        public int Limit
        {
            get => (int)this[ParamName_Limit];
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "不能小于零。");

                this[ParamName_Limit] = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，指示检索返回结果的页序号。
        /// </summary>
        public int Page
        {
            get => (int)this[ParamName_Page];
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "不能小于零。");

                this[ParamName_Page] = value;
            }
        }

        /// <summary>
        /// 获取或设置检索结果的排序方式。
        /// </summary>
        public YandereTagsListOrder Order
        {
            get => (YandereTagsListOrder)Enum.Parse(typeof(YandereTagsListOrder), (string)this[ParamName_Order], true);
            set => this[ParamName_Order] = Enum.GetName(typeof(YandereTagsListOrder), value).ToLower();
        }

        /// <summary>
        /// 获取或设置要检索的 <see cref="YandereTag"/> 的 ID 。
        /// </summary>
        public uint ID
        {
            get => (uint)this[ParamName_ID];
            set => this[ParamName_ID] = value;
        }

        /// <summary>
        /// 获取或设置一个值，当显式设置了这个值后，将检索返回所有 ID 大于这个值的 <see cref="YandereTag"/> 。
        /// </summary>
        public uint AfterID
        {
            get => (uint)this[ParamName_AfterID];
            set => this[ParamName_AfterID] = value;
        }

        /// <summary>
        /// 获取或设置要检索的 <see cref="YandereTag"/> 的名称。
        /// </summary>
        public string Name
        {
            get => (string)this[ParamName_Name];
            set => this[ParamName_Name] = value;
        }

        /// <summary>
        /// 获取或设置要检索的 <see cref="YandereTag"/> 的名称匹配模式。
        /// </summary>
        public string NamePattern
        {
            get => (string)this[ParamName_NamePattern];
            set => this[ParamName_NamePattern] = value;
        }

        public YandereTagsListActionParameters() : base(7)
        {
            this.DefaultParameters.Add(ParamName_Limit, DefaultLimit);
            this.DefaultParameters.Add(ParamName_Page, 1);
            this.DefaultParameters.Add(ParamName_Order, Enum.GetName(typeof(YandereTagsListOrder), YandereTagsListOrder.Name).ToLower());
            this.DefaultParameters.Add(ParamName_ID, uint.MaxValue);
            this.DefaultParameters.Add(ParamName_AfterID, uint.MinValue);
            this.DefaultParameters.Add(ParamName_Name, null);
            this.DefaultParameters.Add(ParamName_NamePattern, DefaultNamePattern);
        }
    }
}
