using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data
{
    public class YanderePostDestroyActionParameters : YandereActionParameters
    {
        public const string ParamName_ID = "id";

        public uint ID
        {
            get => (uint)this[ParamName_ID];
            set => this[ParamName_ID] = value;
        }

        public YanderePostDestroyActionParameters(uint id) : base(1)
        {
            this.AddParameter(ParamName_ID, id);
        }
    }
}
