using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    internal sealed class comment_json
    {
        public uint id { get; set; }
        public string created_at { get; set; }
        public uint post_id { get; set; }
        public string creator { get; set; }
        public uint creator_id { get; set; }
        public string body { get; set; }
    }
}
