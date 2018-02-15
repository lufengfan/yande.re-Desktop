using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YanderePostsListActionParameters : YandereActionParameters
    {
        public const string ParamName_Limit = "limit";
        public const string ParamName_Page = "page";
        public const string ParamName_Tags = "tags";

        public const int DefaultLimit = 40;
        public const int MaxLimit = 100;

        /// <summary>
        /// 获取或设置一个值，指示检索的 <see cref="YanderePost"/> 的数量。硬性规定的最大数量值为 <see cref="MaxLimit"/> 。
        /// </summary>
        public int Limit
        {
            get => (int)this[ParamName_Limit];
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "不能小于零。");

                if (value <= MaxLimit)
                    this[ParamName_Limit] = value;
                else
                    this[ParamName_Limit] = MaxLimit;
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
        /// 获取或设置一个 <see cref="YandereTag"/> 的集合，指定检索的标签。
        /// </summary>
        public YandereTagCollection Tags
        {
            get => (YandereTagCollection)this[ParamName_Tags];
            set => this[ParamName_Tags] = value;
        }

        public YanderePostsListActionParameters() : base(3)
        {
            this.DefaultParameters.Add(ParamName_Limit, DefaultLimit);
            this.DefaultParameters.Add(ParamName_Page, 1);
            this.DefaultParameters.Add(ParamName_Tags, null);
        }
    }
}
